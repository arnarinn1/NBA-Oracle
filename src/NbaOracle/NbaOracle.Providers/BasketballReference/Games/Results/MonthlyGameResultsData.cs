using System.Collections.Generic;
using NbaOracle.Providers.BasketballReference.Games.Results.Parsers.Games.Data;

namespace NbaOracle.Providers.BasketballReference.Games.Results
{
    public class MonthlyGameResultsData
    {
        public MonthlyGameResultsData(IEnumerable<GameData> gameResults)
        {
            GameResults = gameResults;
        }

        public IEnumerable<GameData> GameResults { get; }
    }
}