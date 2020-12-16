using System;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore.Data;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.TeamBoxScore.Data;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class GameDetailsProvider : IGameDetailsProvider
    {
        private readonly IDocumentLoader _documentLoader;
        private readonly GameDetailsProviderSettings _settings;
        private readonly IDocumentParser<LineScoreData> _lineScoreParser;
        private readonly IDocumentParser<TeamBoxScoreData, string> _teamBoxScoreParser;

        public GameDetailsProvider(IDocumentLoader documentLoader, GameDetailsProviderSettings settings, IDocumentParser<LineScoreData> lineScoreParser, IDocumentParser<TeamBoxScoreData, string> teamBoxScoreParser)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _lineScoreParser = lineScoreParser ?? throw new ArgumentNullException(nameof(lineScoreParser));
            _teamBoxScoreParser = teamBoxScoreParser ?? throw new ArgumentNullException(nameof(teamBoxScoreParser));
        }

        public async Task<GameDetailsData> GetGameDetails(Season season, BoxScoreLink boxScoreLink)
        {
            var document = await _documentLoader.LoadDocument(_settings.ToDocumentOptions(season, boxScoreLink));

            var lineScore = _lineScoreParser.Parse(document);
            var homeBoxScore = _teamBoxScoreParser.Parse(document, lineScore.HomeTeam);

            return new GameDetailsData();
        }
    }
}