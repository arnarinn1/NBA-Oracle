using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace BuildingBlocks.StoredProcedureHandlers.Implementations
{
    public abstract class DapperStoredProcedureHandlerWithSingleQueryResult<TRequest, TResult> : IStoredProcedureHandler<TRequest, TResult>
        where TRequest : IStoredProcedureRequest
    {
        private readonly IDbConnection _dbConnection;

        protected DapperStoredProcedureHandlerWithSingleQueryResult(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        protected abstract string ProcedureName { get; }
        protected abstract void AddParameters(TRequest request, DynamicParameters parameters);

        public Task<TResult> Execute(TRequest request)
        {
            var parameters = new DynamicParameters();
            AddParameters(request, parameters);
            return _dbConnection.QuerySingleAsync<TResult>(ProcedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}