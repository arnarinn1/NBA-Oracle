using BuildingBlocks.StoredProcedureHandlers;

namespace NbaOracle.Providers.StoredProcedureRequests.Teams.TeamBySeason
{
    public class MergeTeamBySeasonRequest : IStoredProcedureRequest
    {
        public MergeTeamBySeasonRequest(int seasonId, int teamId, string teamIdentifier, string teamName, int wins, int losses, double marginOfVictory, int winsLeagueRank, int lossesLeagueRank, int marginOfVictoryLeagueRank)
        {
            SeasonId = seasonId;
            TeamId = teamId;
            TeamIdentifier = teamIdentifier;
            TeamName = teamName;
            Wins = wins;
            Losses = losses;
            MarginOfVictory = marginOfVictory;
            WinsLeagueRank = winsLeagueRank;
            LossesLeagueRank = lossesLeagueRank;
            MarginOfVictoryLeagueRank = marginOfVictoryLeagueRank;
        }

        public int SeasonId { get; }
        public int TeamId { get; }
        public string TeamIdentifier { get; }
        public string TeamName { get; }
        public int Wins { get; }
        public int Losses { get; }
        public double MarginOfVictory { get; }
        public int WinsLeagueRank { get; }
        public int LossesLeagueRank { get; }
        public int MarginOfVictoryLeagueRank { get; }
    }
}