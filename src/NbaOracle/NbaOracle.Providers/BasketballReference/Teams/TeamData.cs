using System.Collections.Generic;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay.Data;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics.Data;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc.Data;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public class TeamData
    {
        public TeamData(TeamMiscData teamMisc, IEnumerable<PlayerRoosterData> rooster, IEnumerable<PlayerSeasonStatisticsData> playerStatistics, IEnumerable<PlayByPlayData> playByPlay)
        {
            TeamMisc = teamMisc;
            Rooster = rooster;
            PlayerStatistics = playerStatistics;
            PlayByPlay = playByPlay;
        }

        public TeamMiscData TeamMisc { get; private set; }
        public IEnumerable<PlayerRoosterData> Rooster { get; private set; }
        public IEnumerable<PlayerSeasonStatisticsData> PlayerStatistics { get; private set; }
        public IEnumerable<PlayByPlayData> PlayByPlay { get; private set; }
    }
}