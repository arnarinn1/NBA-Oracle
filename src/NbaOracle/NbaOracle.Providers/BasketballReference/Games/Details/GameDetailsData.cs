using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore.Data;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.TeamBoxScore.Data;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class GameDetailsData
    {
        public LineScoreData LineScore { get; }
        public TeamBoxScoreData HomeBoxScore { get; }
        public TeamBoxScoreData VisitorBoxScore { get; }

        public GameDetailsData(LineScoreData lineScore, TeamBoxScoreData homeBoxScore, TeamBoxScoreData visitorBoxScore)
        {
            LineScore = lineScore;
            HomeBoxScore = homeBoxScore;
            VisitorBoxScore = visitorBoxScore;
        }
    }
}