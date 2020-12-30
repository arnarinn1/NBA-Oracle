using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.StoredProcedureHandlers;
using NbaOracle.Providers.StoredProcedureRequests.Players;
using NbaOracle.Providers.StoredProcedureRequests.Teams;
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

        public PersistTeamDataToDatabaseProcessor(IStoredProcedureHandler<MergePlayersRequest, IEnumerable<MergePlayerResult>> handler, IStoredProcedureHandler<MergeTeamBySeasonRequest, MergeTeamBySeasonResult> mergeTeamBySeasonHandler, IStoredProcedureHandler<MergeTeamRoosterBySeasonRequest, bool> mergeTeamRoosterBySeasonHandler)
        {
            _mergePlayersHandler = handler ?? throw new ArgumentNullException(nameof(handler));
            _mergeTeamBySeasonHandler = mergeTeamBySeasonHandler ?? throw new ArgumentNullException(nameof(mergeTeamBySeasonHandler));
            _mergeTeamRoosterBySeasonHandler = mergeTeamRoosterBySeasonHandler ?? throw new ArgumentNullException(nameof(mergeTeamRoosterBySeasonHandler));
        }

        public async Task Process(Team team, Season season, TeamData teamData)
        {
            var players = (await _mergePlayersHandler.Execute(MergePlayersRequestFactory.CreateFromPlayerRooster(teamData.Rooster))).ToArray();
            
            var teamBySeason = await _mergeTeamBySeasonHandler.Execute(TeamsRequestFactory.CreateMergeTeamBySeasonRequest(team, season, teamData));

            await _mergeTeamRoosterBySeasonHandler.Execute(TeamsRequestFactory.CreateMergeTeamRoosterBySeasonRequest(teamBySeason.TeamBySeasonId, teamData.Rooster, players));
        }
    }
}