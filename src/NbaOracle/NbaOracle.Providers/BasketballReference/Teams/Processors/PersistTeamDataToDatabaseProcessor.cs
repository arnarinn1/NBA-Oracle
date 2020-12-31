using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.StoredProcedureHandlers;
using NbaOracle.Providers.StoredProcedureRequests.Players;
using NbaOracle.Providers.StoredProcedureRequests.Teams;
using NbaOracle.Providers.StoredProcedureRequests.Teams.PlayerSeasonStatistics;
using NbaOracle.Providers.StoredProcedureRequests.Teams.TeamBySeason;
using NbaOracle.Providers.StoredProcedureRequests.Teams.TeamRoosterBySeason;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams.Processors
{
    public class PersistTeamDataToDatabaseProcessor : ITeamProcessor
    {
        private readonly IStoredProcedureHandler<MergePlayersRequest, IEnumerable<MergePlayerResult>> _mergePlayersHandler;
        private readonly IStoredProcedureHandler<MergeTeamBySeasonRequest, MergeTeamBySeasonResult> _mergeTeamBySeasonHandler;
        private readonly IStoredProcedureHandler<MergeTeamRoosterBySeasonRequest, bool> _mergeTeamRoosterBySeasonHandler;
        private readonly IStoredProcedureHandler<MergePlayerSeasonStatisticsRequest, bool> _mergePlayerSeasonStatisticsHandler;

        public PersistTeamDataToDatabaseProcessor(
            IStoredProcedureHandler<MergePlayersRequest, IEnumerable<MergePlayerResult>> mergePlayersHandler, 
            IStoredProcedureHandler<MergeTeamBySeasonRequest, MergeTeamBySeasonResult> mergeTeamBySeasonHandler, 
            IStoredProcedureHandler<MergeTeamRoosterBySeasonRequest, bool> mergeTeamRoosterBySeasonHandler, 
            IStoredProcedureHandler<MergePlayerSeasonStatisticsRequest, bool> mergePlayerSeasonStatisticsHandler)
        {
            _mergePlayersHandler = mergePlayersHandler ?? throw new ArgumentNullException(nameof(mergePlayersHandler));
            _mergeTeamBySeasonHandler = mergeTeamBySeasonHandler ?? throw new ArgumentNullException(nameof(mergeTeamBySeasonHandler));
            _mergeTeamRoosterBySeasonHandler = mergeTeamRoosterBySeasonHandler ?? throw new ArgumentNullException(nameof(mergeTeamRoosterBySeasonHandler));
            _mergePlayerSeasonStatisticsHandler = mergePlayerSeasonStatisticsHandler ?? throw new ArgumentNullException(nameof(mergePlayerSeasonStatisticsHandler));
        }

        public async Task Process(Team team, Season season, TeamData teamData)
        {
            var players = (await _mergePlayersHandler.Execute(MergePlayersRequestFactory.CreateFromPlayerRooster(teamData.Rooster))).ToArray();
            
            var teamBySeason = await _mergeTeamBySeasonHandler.Execute(TeamsRequestFactory.CreateMergeTeamBySeasonRequest(team, season, teamData));

            await _mergeTeamRoosterBySeasonHandler.Execute(TeamsRequestFactory.CreateMergeTeamRoosterBySeasonRequest(teamBySeason.TeamBySeasonId, teamData.Rooster, players));

            await _mergePlayerSeasonStatisticsHandler.Execute(TeamsRequestFactory.CreateMergePlayerSeasonStatisticsRequest());
        }
    }
}