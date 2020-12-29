using System.Collections.Generic;
using System.Linq;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data;

namespace NbaOracle.Providers.StoredProcedureRequests.PersistPlayers
{
    public class PersistPlayersRequestFactory
    {
        public static PersistPlayersRequest CreateFromPlayerRooster(IEnumerable<PlayerRoosterData> playerRooster)
        {
            var players = playerRooster.Select(x => new PlayerRequestData(x.GetPlayerIdentifier(), x.Name, x.BirthDate, x.BirthCountry, x.College));
            return new PersistPlayersRequest(players);
        }
    }
}