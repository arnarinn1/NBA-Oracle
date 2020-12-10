namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc.Data
{
    public class TeamMiscData
    {
        public TeamMiscData(int wins, int winsLeagueRank, int losses, int lossesLeagueRank, double marginOfVictory, int marginOfVictoryLeagueRank)
        {
            Wins = wins;
            Losses = losses;
            WinsLeagueRank = winsLeagueRank;
            LossesLeagueRank = lossesLeagueRank;
            MarginOfVictory = marginOfVictory;
            MarginOfVictoryLeagueRank = marginOfVictoryLeagueRank;
        }

        public int Wins { get; }
        public int WinsLeagueRank { get; }

        public int Losses { get; }
        public int LossesLeagueRank { get; }

        public double MarginOfVictory { get; }
        public int MarginOfVictoryLeagueRank { get; }
    }
}