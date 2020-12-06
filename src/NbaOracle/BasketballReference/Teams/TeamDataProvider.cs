using System;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public class TeamDataProvider : ITeamDataProvider
    {
        private readonly IDocumentLoader _documentLoader;
        private readonly TeamDataProviderSettings _providerSettings;

        private readonly TeamRoosterParser _roosterParser;
        private readonly PlayerSeasonStatisticsParser _seasonStatisticsParser;

        public TeamDataProvider(IDocumentLoader documentLoader, TeamDataProviderSettings providerSettings)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _providerSettings = providerSettings ?? throw new ArgumentNullException(nameof(providerSettings));

            _roosterParser = new TeamRoosterParser();
            _seasonStatisticsParser = new PlayerSeasonStatisticsParser();
        }

        public async Task GetTeamData(Team team, SeasonIdentifier season)
        {
            var document = await _documentLoader.LoadDocument(_providerSettings.ToDocumentOptions(team, season));

            var rooster = _roosterParser.Parse(document);
            var playerSeasonStatistics = _seasonStatisticsParser.Parse(document);
        }
    }
}