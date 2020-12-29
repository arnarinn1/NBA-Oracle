using System.Collections.Generic;
using System.Linq;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data;

namespace NbaOracle.Providers.StoredProcedureRequests.Players
{
    public class MergePlayersRequestFactory
    {
        public static MergePlayersRequest CreateFromPlayerRooster(IEnumerable<PlayerRoosterData> playerRooster)
        {
            var players = playerRooster.Select(x => new PlayerRequestData(x.GetPlayerIdentifier(), x.Name, x.BirthDate, x.BirthCountry, x.College));
            return new MergePlayersRequest(players);
        }
    }
}