using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay.Data;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics.Data;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc.Data;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public class TeamProvider : ITeamProvider
    {
        private readonly IDocumentLoader _documentLoader;
        private readonly TeamProviderSettings _providerSettings;

        private readonly IDocumentParser<IEnumerable<PlayerRoosterData>> _teamRoosterParser;
        private readonly IDocumentParser<IEnumerable<PlayerSeasonStatisticsData>> _playerSeasonStatisticsParser;
        private readonly IDocumentParser<IEnumerable<PlayByPlayData>> _playByPlayParser;
        private readonly IDocumentParser<TeamMiscData> _teamMiscParser;

        public TeamProvider(IDocumentLoader documentLoader, TeamProviderSettings providerSettings, IDocumentParser<IEnumerable<PlayerRoosterData>> teamRoosterParser, IDocumentParser<IEnumerable<PlayerSeasonStatisticsData>> playerSeasonStatisticsParser, IDocumentParser<IEnumerable<PlayByPlayData>> playByPlayParser, IDocumentParser<TeamMiscData> teamMiscParser)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _providerSettings = providerSettings ?? throw new ArgumentNullException(nameof(providerSettings));

            _teamRoosterParser = teamRoosterParser ?? throw new ArgumentNullException(nameof(teamRoosterParser));
            _playerSeasonStatisticsParser = playerSeasonStatisticsParser ?? throw new ArgumentNullException(nameof(playerSeasonStatisticsParser));
            _playByPlayParser = playByPlayParser ?? throw new ArgumentNullException(nameof(playByPlayParser));
            _teamMiscParser = teamMiscParser ?? throw new ArgumentNullException(nameof(teamMiscParser));
        }

        public async Task<TeamData> GetTeamData(Team team, Season season)
        {
            var document = await _documentLoader.LoadDocument(_providerSettings.ToDocumentOptions(team, season));

            var rooster = _teamRoosterParser.Parse(document);
            var playerSeasonStatistics = _playerSeasonStatisticsParser.Parse(document);
            var playByPlay = _playByPlayParser.Parse(document);
            var teamMisc = _teamMiscParser.Parse(document);

            return new TeamData(teamMisc, rooster, playerSeasonStatistics, playByPlay);
        }
    }
}