namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay.Data
{
    public class PlayByPlayData
    {
        public string PlayerName { get; }
        public string PlusMinusOnCourt { get; }
        public string PlusMinusNetOnCourt { get; }

        public PlayByPlayData(string playerName, string plusMinusOnCourt, string plusMinusNetOnCourt)
        {
            PlayerName = playerName;
            PlusMinusOnCourt = plusMinusOnCourt;
            PlusMinusNetOnCourt = plusMinusNetOnCourt;
        }

        public override string ToString()
        {
            return $"{PlayerName} - ({PlusMinusOnCourt})";
        }
    }
}