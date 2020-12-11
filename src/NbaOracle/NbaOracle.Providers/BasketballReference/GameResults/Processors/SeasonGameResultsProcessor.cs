using System.Collections.Generic;
using System.Threading.Tasks;
using NbaOracle.Providers.BasketballReference.GameResults.Parsers.Games.Data;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameResults.Processors
{
    public class SeasonGameResultsProcessor : ISeasonGameResultsProcessor
    {
        public Task Process(Season season, IEnumerable<GameData> games)
        {
            return Task.CompletedTask;
        }
    }
}