using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace BuildingBlocks.StoredProcedureHandlers.Implementations
{
    public abstract class DapperStoredProcedureHandler<TRequest, TResult> : IStoredProcedureHandler<TRequest, TResult>
        where TRequest : IStoredProcedureRequest
    {
        private readonly IDbConnection _dbConnection;

        protected DapperStoredProcedureHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        protected abstract string ProcedureName { get; }

        protected abstract TResult CreateResult(TRequest request, DynamicParameters parameters);

        protected abstract void AddParameters(TRequest request, DynamicParameters parameters);

        public async Task<TResult> Execute(TRequest request)
        {
            var parameters = new DynamicParameters();
            AddParameters(request, parameters);
            
            await _dbConnection.ExecuteAsync(ProcedureName, parameters, commandType:CommandType.StoredProcedure);

            return CreateResult(request, parameters);
        }
    }
}