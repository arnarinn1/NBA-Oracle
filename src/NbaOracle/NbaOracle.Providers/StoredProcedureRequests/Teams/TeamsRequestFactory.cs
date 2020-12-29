using NbaOracle.Providers.BasketballReference.Teams;
using NbaOracle.Providers.StoredProcedureRequests.Teams.TeamBySeason;
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
    }
}