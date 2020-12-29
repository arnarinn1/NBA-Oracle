using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace BuildingBlocks.StoredProcedureHandlers.Implementations
{
    public abstract class DapperStoredProcedureHandlerWithQueryResult<TRequest, TResult> : IStoredProcedureHandler<TRequest, IEnumerable<TResult>>
        where TRequest : IStoredProcedureRequest
    {
        private readonly IDbConnection _dbConnection;

        protected DapperStoredProcedureHandlerWithQueryResult(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        protected abstract string ProcedureName { get; }
        protected abstract void AddParameters(TRequest request, DynamicParameters parameters);

        public Task<IEnumerable<TResult>> Execute(TRequest request)
        {
            var parameters = new DynamicParameters();
            AddParameters(request, parameters);
            return _dbConnection.QueryAsync<TResult>(ProcedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}