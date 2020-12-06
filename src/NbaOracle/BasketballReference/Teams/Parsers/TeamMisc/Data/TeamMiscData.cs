namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc.Data
{
    public class TeamMiscData
    {
        public TeamMiscData(string wins, string winsLeagueRank, string losses, string lossesLeagueRank, string marginOfVictory, string marginOfVictoryLeagueRank)
        {
            Wins = wins;
            Losses = losses;
            WinsLeagueRank = winsLeagueRank;
            LossesLeagueRank = lossesLeagueRank;
            MarginOfVictory = marginOfVictory;
            MarginOfVictoryLeagueRank = marginOfVictoryLeagueRank;
        }

        public string Wins { get; }
        public string WinsLeagueRank { get; }

        public string Losses { get; }
        public string LossesLeagueRank { get; }

        public string MarginOfVictory { get; }
        public string MarginOfVictoryLeagueRank { get; }
    }
}