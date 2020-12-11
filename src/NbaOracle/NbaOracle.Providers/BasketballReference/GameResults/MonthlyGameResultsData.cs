using System.Collections.Generic;
using NbaOracle.Providers.BasketballReference.GameResults.Parsers.Games.Data;

namespace NbaOracle.Providers.BasketballReference.GameResults
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