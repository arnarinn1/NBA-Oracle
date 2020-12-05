using System;
using System.Collections.Generic;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster
{
    public class TeamRoosterData
    {
        public TeamRoosterData()
        {
            Players = new List<PlayerRoosterData>();
        }

        public ICollection<PlayerRoosterData> Players { get; }

        public void AddPlayer(PlayerRoosterData player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Players.Add(player);
        }
    }
}