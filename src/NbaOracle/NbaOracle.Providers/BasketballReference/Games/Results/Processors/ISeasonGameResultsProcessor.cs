using System.Collections.Generic;
using System.Threading.Tasks;
using NbaOracle.Providers.BasketballReference.Games.Results.Parsers.Games.Data;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Results.Processors
{
    public interface ISeasonGameResultsProcessor
    {
        Task Process(Season season, IEnumerable<GameData> games);
    }
}