using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay.Data
{
    public class PlayByPlayData
    {
        public string PlayerName { get; }
        public int Games { get; }
        public int MinutesPlayed { get; }
        public double PlusMinusOnCourt { get; }
        public double PlusMinusNetOnOffCourt { get; }

        public PlayByPlayData(string playerName, int games, int minutesPlayed, string plusMinusOnCourt, string plusMinusNetOnOffCourt)
        {
            PlayerName = playerName;
            Games = games;
            MinutesPlayed = minutesPlayed;
            PlusMinusOnCourt = string.IsNullOrWhiteSpace(plusMinusOnCourt) ? 0.0 : new PlusMinusScore(plusMinusOnCourt);
            PlusMinusNetOnOffCourt = string.IsNullOrWhiteSpace(plusMinusNetOnOffCourt) ? 0.0 : new PlusMinusScore(plusMinusNetOnOffCourt);
        }

        public override string ToString()
        {
            return $"{PlayerName} - ({PlusMinusOnCourt})";
        }
    }
}