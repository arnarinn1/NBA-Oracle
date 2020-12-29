using System.Collections.Generic;
using BuildingBlocks.StoredProcedureHandlers;

namespace NbaOracle.Providers.StoredProcedureRequests.PersistPlayers
{
    public class PersistPlayersRequest : IStoredProcedureRequest
    {
        public PersistPlayersRequest(IEnumerable<PlayerRequestData> players)
        {
            Players = players;
        }

        public IEnumerable<PlayerRequestData> Players { get; }
    }
}