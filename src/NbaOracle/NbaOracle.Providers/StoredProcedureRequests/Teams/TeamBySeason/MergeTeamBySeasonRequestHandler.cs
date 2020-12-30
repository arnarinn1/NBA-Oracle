using System.Data;
using BuildingBlocks.StoredProcedureHandlers.Implementations;
using Dapper;

namespace NbaOracle.Providers.StoredProcedureRequests.Teams.TeamBySeason
{
    public class MergeTeamBySeasonRequestHandler : DapperStoredProcedureHandlerWithSingleQueryResult<MergeTeamBySeasonRequest, MergeTeamBySeasonResult>
    {
        public MergeTeamBySeasonRequestHandler(IDbConnection dbConnection) : base(dbConnection) { }

        protected override string ProcedureName => "nba.sp_MergeTeamBySeason";

        protected override void AddParameters(MergeTeamBySeasonRequest request, DynamicParameters parameters)
        {
            var dt = new DataTable();
            dt.Columns.Add("SeasonId", typeof(int));
            dt.Columns.Add("TeamId", typeof(int));
            dt.Columns.Add("TeamIdentifier", typeof(string));
            dt.Columns.Add("TeamName", typeof(string));
            dt.Columns.Add("Wins", typeof(int));
            dt.Columns.Add("Losses", typeof(int));
            dt.Columns.Add("MarginOfVictory", typeof(double));
            dt.Columns.Add("WinsLeagueRank", typeof(int));
            dt.Columns.Add("LossesLeagueRank", typeof(int));
            dt.Columns.Add("MarginOfVictoryLeagueRank", typeof(int));

            dt.Rows.Add(request.SeasonId, request.TeamId, request.TeamIdentifier, request.TeamName, request.Wins, request.Losses, request.MarginOfVictory, request.WinsLeagueRank, request.LossesLeagueRank, request.MarginOfVictoryLeagueRank);

            parameters.Add("@Teams", dt.AsTableValuedParameter("nba.tt_MergeTeamBySeasonDataType"));
        }
    }
}