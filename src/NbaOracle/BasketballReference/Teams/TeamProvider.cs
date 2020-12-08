using System;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public class TeamProvider : ITeamProvider
    {
        private readonly IDocumentLoader _documentLoader;
        private readonly TeamProviderSettings _providerSettings;

        private readonly TeamRoosterParser _roosterParser;
        private readonly PlayerSeasonStatisticsParser _seasonStatisticsParser;
        private readonly PlayByPlayParser _playByPlayParser;
        private readonly TeamMiscParser _teamMiscParser;

        public TeamProvider(IDocumentLoader documentLoader, TeamProviderSettings providerSettings)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _providerSettings = providerSettings ?? throw new ArgumentNullException(nameof(providerSettings));

            _roosterParser = new TeamRoosterParser();
            _seasonStatisticsParser = new PlayerSeasonStatisticsParser();
            _playByPlayParser = new PlayByPlayParser();
            _teamMiscParser = new TeamMiscParser();
        }

        public async Task<TeamData> GetTeamData(Team team, Season season)
        {
            var document = await _documentLoader.LoadDocument(_providerSettings.ToDocumentOptions(team, season));

            var rooster = _roosterParser.Parse(document);
            var playerSeasonStatistics = _seasonStatisticsParser.Parse(document);
            var playByPlay = _playByPlayParser.Parse(document);
            var teamMisc = _teamMiscParser.Parse(document);

            return new TeamData(teamMisc, rooster, playerSeasonStatistics, playByPlay);
        }
    }
}