using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore.Data;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.TeamBoxScore.Data;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class GameDetailsData
    {
        public string HomeTeam { get; }
        public string VisitorTeam { get; }
        public LineScoreData LineScore { get; }
        public TeamBoxScoreData HomeBoxScore { get; }
        public TeamBoxScoreData VisitorBoxScore { get; }

        public GameDetailsData(string homeTeam, string visitorTeam, LineScoreData lineScore, TeamBoxScoreData homeBoxScore, TeamBoxScoreData visitorBoxScore)
        {
            HomeTeam = homeTeam;
            VisitorTeam = visitorTeam;
            LineScore = lineScore;
            HomeBoxScore = homeBoxScore;
            VisitorBoxScore = visitorBoxScore;
        }
    }
}