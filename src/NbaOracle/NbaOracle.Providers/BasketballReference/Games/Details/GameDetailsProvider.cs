using System;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore.Data;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class GameDetailsProvider : IGameDetailsProvider
    {
        private readonly IDocumentLoader _documentLoader;
        private readonly GameDetailsProviderSettings _settings;
        private readonly IDocumentParser<LineScoreData> _lineScoreParser;

        public GameDetailsProvider(IDocumentLoader documentLoader, GameDetailsProviderSettings settings, IDocumentParser<LineScoreData> lineScoreParser)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _lineScoreParser = lineScoreParser ?? throw new ArgumentNullException(nameof(lineScoreParser));
        }

        public async Task<GameDetailsData> GetGameDetails(Season season, BoxScoreLink boxScoreLink)
        {
            var document = await _documentLoader.LoadDocument(_settings.ToDocumentOptions(season, boxScoreLink));

            var lineScore = _lineScoreParser.Parse(document);

            return new GameDetailsData(); ;
        }
    }
}