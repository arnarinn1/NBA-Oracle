using System;
using System.Collections.Generic;
using System.Linq;

namespace NbaOracle.Providers.BasketballReference.Games.Details.Parsers.TeamBoxScore.Data
{
    public class TeamBoxScoreData
    {
        public TeamBoxScoreData(int currentNumberOfWins, int currentNumberOfLosses)
        {
            CurrentNumberOfWins = currentNumberOfWins;
            CurrentNumberOfLosses = currentNumberOfLosses;
        }

        public int CurrentNumberOfWins { get; }
        public int CurrentNumberOfLosses { get; }

        public ICollection<PlayerBoxScoreData> Players { get; } = new List<PlayerBoxScoreData>();
        public ICollection<string> DidNotPlay { get; } = new List<string>();

        public int TotalSecondsPlayed { get; private set; }

        public int TotalFieldGoalsMade { get; private set; }
        public int TotalFieldGoalsAttempted { get; private set; }
        public double TotalFieldGoalPercentage { get; private set; }

        public int TotalThreePointersMade { get; private set; }
        public int TotalThreePointersAttempted { get; private set; }
        public double TotalThreePointersPercentage { get; private set; }

        public int TotalFreeThrowsMade { get; private set; }
        public int TotalFreeThrowsAttempted { get; private set; }
        public double TotalFreeThrowsPercentage { get; private set; }

        public int TotalOffensiveRebounds { get; private set; }
        public int TotalDefensiveRebounds { get; private set; }
        public int TotalRebounds { get; private set; }

        public int TotalAssists { get; private set; }
        public int TotalSteals { get; private set; }
        public int TotalBlocks { get; private set; }
        public int TotalTurnovers { get; private set; }
        public int TotalPersonalFouls { get; private set; }
        public int TotalPoints { get; private set; }

        public void AddPlayer(PlayerBoxScoreData player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            Players.Add(player);

            TotalSecondsPlayed += player.SecondsPlayed;

            TotalFieldGoalsMade =+ player.FieldGoalsMade;
            TotalFieldGoalsAttempted =+ player.FieldGoalsAttempted;
            TotalFieldGoalPercentage = Divide(Players.Sum(x => x.FieldGoalsMade), Players.Sum(x => x.FieldGoalsAttempted));

            TotalThreePointersMade =+ player.ThreePointersMade;
            TotalThreePointersAttempted =+ player.ThreePointersAttempted;
            TotalThreePointersPercentage = Divide(Players.Sum(x => x.ThreePointersMade), Players.Sum(x => x.ThreePointersAttempted));

            TotalFreeThrowsMade =+ player.FreeThrowsMade;
            TotalFreeThrowsAttempted =+ player.FreeThrowsAttempted;
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