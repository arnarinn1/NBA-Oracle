using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.GameResults.Parsers.Games.Data;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameResults
{
    public class MonthlyGameResultsProvider : IMonthlyGameResultsProvider
    {
        private readonly IDocumentLoader _documentLoader;
        private readonly MonthlyGameResultsProviderSettings _settings;
        private readonly IDocumentParser<IEnumerable<GameData>> _gameResultsParser;

        public MonthlyGameResultsProvider(IDocumentLoader documentLoader, MonthlyGameResultsProviderSettings settings, IDocumentParser<IEnumerable<GameData>> gameResultParser)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _gameResultsParser = gameResultParser ?? throw new ArgumentNullException(nameof(gameResultParser));
        }

        public async Task<MonthlyGameResultsData> GetSchedule(Season season, Month month)
        {
            var document = await _documentLoader.LoadDocument(_settings.ToDocumentOptions(season, month));

            var gameResults = _gameResultsParser.Parse(document);

            return new MonthlyGameResultsData(gameResults);
        }
    }
}