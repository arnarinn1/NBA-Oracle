using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay.Data
{
    public class PlayByPlayData
    {
        public static PlayByPlayData Create(string playerName, int games, int minutesPlayed, string plusMinusOnCourt, string plusMinusNetOnOffCourt)
        {
            return new PlayByPlayData(playerName, games, minutesPlayed, string.IsNullOrWhiteSpace(plusMinusOnCourt) ? 0.0 : new PlusMinusScore(plusMinusOnCourt), string.IsNullOrWhiteSpace(plusMinusNetOnOffCourt) ? 0.0 : new PlusMinusScore(plusMinusNetOnOffCourt));
        }

        public string PlayerName { get; }
        public int Games { get; }
        public int MinutesPlayed { get; }
        public double PlusMinusOnCourt { get; }
        public double PlusMinusNetOnOffCourt { get; }

        public PlayByPlayData(string playerName, int games, int minutesPlayed, double plusMinusOnCourt, double plusMinusNetOnOffCourt)
        {
            PlayerName = playerName;
            Games = games;
            MinutesPlayed = minutesPlayed;
            PlusMinusOnCourt = plusMinusOnCourt;
            PlusMinusNetOnOffCourt = plusMinusNetOnOffCourt;
        }

        public override string ToString()
        {
            return $"{PlayerName} - ({PlusMinusOnCourt})";
        }
    }
}