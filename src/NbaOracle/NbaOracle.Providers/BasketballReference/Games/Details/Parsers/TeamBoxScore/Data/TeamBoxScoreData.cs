using System;
using System.Collections.Generic;
using System.Linq;

namespace NbaOracle.Providers.BasketballReference.Games.Details.Parsers.TeamBoxScore.Data
{
    public class TeamBoxScoreData
    {
        public TeamBoxScoreData() { }

        public int CurrentNumberOfWins { get; set; }
        public int CurrentNumberOfLosses { get; set; }

        public ICollection<PlayerBoxScoreData> Players { get; set; } = new List<PlayerBoxScoreData>();
        public ICollection<string> DidNotPlay { get; set; } = new List<string>();

        public int TotalSecondsPlayed { get; set; }

        public int TotalFieldGoalsMade { get; set; }
        public int TotalFieldGoalsAttempted { get; set; }
        public double TotalFieldGoalPercentage { get; set; }

        public int TotalThreePointersMade { get; set; }
        public int TotalThreePointersAttempted { get; set; }
        public double TotalThreePointersPercentage { get; set; }

        public int TotalFreeThrowsMade { get; set; }
        public int TotalFreeThrowsAttempted { get; set; }
        public double TotalFreeThrowsPercentage { get; set; }

        public int TotalOffensiveRebounds { get; set; }
        public int TotalDefensiveRebounds { get; set; }
        public int TotalRebounds { get; set; }

        public int TotalAssists { get; set; }
        public int TotalSteals { get; set; }
        public int TotalBlocks { get; set; }
        public int TotalTurnovers { get; set; }
        public int TotalPersonalFouls { get; set; }
        public int TotalPoints { get; set; }

        public void AddPlayer(PlayerBoxScoreData player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Players.Add(player);

            TotalSecondsPlayed += player.SecondsPlayed;

            TotalFieldGoalsMade += player.FieldGoalsMade;
            TotalFieldGoalsAttempted += player.FieldGoalsAttempted;
            TotalFieldGoalPercentage = Divide(Players.Sum(x => x.FieldGoalsMade), Players.Sum(x => x.FieldGoalsAttempted));

            TotalThreePointersMade += player.ThreePointersMade;
            TotalThreePointersAttempted += player.ThreePointersAttempted;
            TotalThreePointersPercentage = Divide(Players.Sum(x => x.ThreePointersMade), Players.Sum(x => x.ThreePointersAttempted));

            TotalFreeThrowsMade += player.FreeThrowsMade;
            TotalFreeThrowsAttempted += player.FreeThrowsAttempted;
            TotalFreeThrowsPercentage = Divide(Players.Sum(x => x.FreeThrowsMade), Players.Sum(x => x.FreeThrowsAttempted));

            TotalOffensiveRebounds += player.OffensiveRebounds;
            TotalDefensiveRebounds += player.DefensiveRebounds;
            TotalRebounds += player.TotalRebounds;

            TotalAssists += player.Assists;
            TotalSteals += player.Steals;
            TotalBlocks += player.Blocks;
            TotalTurnovers += player.Turnovers;
            TotalPersonalFouls += player.PersonalFouls;
            TotalPoints += player.Points;

            static double Divide(int left, int right, int decimals = 3) => right == 0 ? 0 : Math.Round((double)left / right, decimals);
        }

        public void AddDidNotPlay(string playerName)
        {
            DidNotPlay.Add(playerName);
        }
    }
}