using System.Collections.Generic;
using BuildingBlocks.StoredProcedureHandlers;

namespace NbaOracle.Providers.StoredProcedureRequests.Teams.TeamRoosterBySeason
{
    public class MergeTeamRoosterBySeasonRequest : IStoredProcedureRequest
    {
        public MergeTeamRoosterBySeasonRequest(IEnumerable<PlayerOnRoosterRequestData> players)
        {
            Players = players;
        }

        public IEnumerable<PlayerOnRoosterRequestData> Players { get; }
    }
}