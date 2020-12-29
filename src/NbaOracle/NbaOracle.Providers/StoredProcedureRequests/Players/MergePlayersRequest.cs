using System.Collections.Generic;
using BuildingBlocks.StoredProcedureHandlers;

namespace NbaOracle.Providers.StoredProcedureRequests.Players
{
    public class MergePlayersRequest : IStoredProcedureRequest
    {
        public MergePlayersRequest(IEnumerable<PlayerRequestData> players)
        {
            Players = players;
        }

        public IEnumerable<PlayerRequestData> Players { get; }
    }
}