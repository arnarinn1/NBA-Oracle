using System.Data;
using BuildingBlocks.StoredProcedureHandlers.Implementations;
using Dapper;

namespace NbaOracle.Providers.StoredProcedureRequests.Teams.TeamRoosterBySeason
{
    public class MergeTeamRoosterBySeasonRequestHandler : DapperStoredProcedureHandler<MergeTeamRoosterBySeasonRequest, bool>
    {
        public MergeTeamRoosterBySeasonRequestHandler(IDbConnection dbConnection) : base(dbConnection) { }

        protected override string ProcedureName => "nba.sp_MergeTeamRoosterBySeason";
        
        protected override void AddParameters(MergeTeamRoosterBySeasonRequest request, DynamicParameters parameters)
        {
            var dt = new DataTable();
            dt.Columns.Add("TeamBySeasonId", typeof(int));
            dt.Columns.Add("PlayerId", typeof(int));
            dt.Columns.Add("JerseyNumber", typeof(string));
            dt.Columns.Add("Position", typeof(string));
            dt.Columns.Add("Height", typeof(double));
            dt.Columns.Add("Weight", typeof(double));
            dt.Columns.Add("NumberOfYearInLeague", typeof(int));

            foreach (var player in request.Players)
            {
                dt.Rows.Add(player.TeamBySeasonId, player.PlayerId, player.JerseyNumber, player.Position, player.Height, player.Weight, player.NumberOfYearInLeague);
            }
            
            parameters.Add("@Rooster", dt.AsTableValuedParameter("nba.tt_MergeTeamRoosterBySeasonDataType"));
        }

        protected override bool CreateResult(MergeTeamRoosterBySeasonRequest request, DynamicParameters parameters) => true;
    }
}