using System;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.BoxScore;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class GameDetailsProvider : IGameDetailsProvider
    {
        private readonly IDocumentLoader _documentLoader;
        private readonly GameDetailsProviderSettings _settings;
        private readonly IDocumentParser<object> _gameDetailsParser;

        public GameDetailsProvider(IDocumentLoader documentLoader, GameDetailsProviderSettings settings)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _gameDetailsParser = new GameDetailsParser();
        }

        public async Task<GameDetailsData> GetGameDetails(Season season, BoxScoreLink boxScoreLink)
        {
            var document = await _documentLoader.LoadDocument(_settings.ToDocumentOptions(season, boxScoreLink));

            var gameDetails = new GameDetailsData();

            _gameDetailsParser.Parse(document);

            return gameDetails;
        }
    }
}