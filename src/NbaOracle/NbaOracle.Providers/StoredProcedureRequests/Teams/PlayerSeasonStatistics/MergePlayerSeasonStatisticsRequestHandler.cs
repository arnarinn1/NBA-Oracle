using System.Data;
using BuildingBlocks.StoredProcedureHandlers.Implementations;
using Dapper;

namespace NbaOracle.Providers.StoredProcedureRequests.Teams.PlayerSeasonStatistics
{
    public class MergePlayerSeasonStatisticsRequestHandler : DapperStoredProcedureHandler<MergePlayerSeasonStatisticsRequest, bool>
    {
        public MergePlayerSeasonStatisticsRequestHandler(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        protected override string ProcedureName => "TODO";
        
        protected override void AddParameters(MergePlayerSeasonStatisticsRequest request, DynamicParameters parameters)
        {
            var dt = new DataTable();

            foreach (var playerStatistics in request.PlayerStatistics)
            {
                
            }

            parameters.Add("@PlayerStatistics", dt.AsTableValuedParameter("nba.tt_MergePlayerSeasonStatisticsDataType"));
        }

        protected override bool CreateResult(MergePlayerSeasonStatisticsRequest request, DynamicParameters parameters) => true;
    }
}