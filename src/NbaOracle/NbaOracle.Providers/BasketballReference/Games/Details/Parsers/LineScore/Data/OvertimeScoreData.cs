namespace NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore.Data
{
    public class OvertimeScoreData
    {
        public OvertimeScoreData(int quarter, int score)
        {
            Quarter = quarter;
            Score = score;
        }

        public int Quarter { get; }
        public int Score { get; }
    }
}