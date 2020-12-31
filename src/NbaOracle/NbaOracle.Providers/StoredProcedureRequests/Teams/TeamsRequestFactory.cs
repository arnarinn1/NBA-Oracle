using System.Collections.Generic;
using System.Linq;
using NbaOracle.Providers.BasketballReference.Teams;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data;
using NbaOracle.Providers.StoredProcedureRequests.Players;
using NbaOracle.Providers.StoredProcedureRequests.Teams.PlayerSeasonStatistics;
using NbaOracle.Providers.StoredProcedureRequests.Teams.TeamBySeason;
using NbaOracle.Providers.StoredProcedureRequests.Teams.TeamRoosterBySeason;
using ValueObjects;

namespace NbaOracle.Providers.StoredProcedureRequests.Teams
{
    public class TeamsRequestFactory
    {
        public static MergeTeamBySeasonRequest CreateMergeTeamBySeasonRequest(Team team, Season season, TeamData teamData)
        {
            var m = teamData.TeamMisc;
            return new MergeTeamBySeasonRequest(season.SeasonEndYear, team.GetIdentifier(), team.NameIdentifier, team.Name, m.Wins, m.Losses, m.MarginOfVictory, m.WinsLeagueRank, m.LossesLeagueRank, m.MarginOfVictoryLeagueRank);
        }

        public static MergeTeamRoosterBySeasonRequest CreateMergeTeamRoosterBySeasonRequest(int teamBySeasonId, IEnumerable<PlayerRoosterData> rooster, IEnumerable<MergePlayerResult> players)
        {
            var playersOnRooster = rooster.Select(x => new PlayerOnRoosterRequestData(teamBySeasonId, players.Single(p => p.PlayerIdentifier == x.GetPlayerIdentifier()).PlayerId, x.JerseyNumber, x.Position, x.Height, x.Weight, x.NumberOfYearInLeague));
            return new MergeTeamRoosterBySeasonRequest(playersOnRooster);
        }

        public static MergePlayerSeasonStatisticsRequest CreateMergePlayerSeasonStatisticsRequest()
        {
            return new MergePlayerSeasonStatisticsRequest(null);
        }
    }
}