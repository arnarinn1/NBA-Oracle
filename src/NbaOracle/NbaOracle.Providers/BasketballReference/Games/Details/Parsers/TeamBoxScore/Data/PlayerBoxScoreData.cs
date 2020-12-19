using System;

namespace NbaOracle.Providers.BasketballReference.Games.Details.Parsers.TeamBoxScore.Data
{
    public class PlayerBoxScoreData
    {
        public string PlayerName { get; }
        public bool Starter { get; }

        public int SecondsPlayed { get; }

        public int FieldGoalsMade { get; }
        public int FieldGoalsAttempted { get; }
        public double FieldGoalPercentage { get; }

        public int ThreePointersMade { get; }
        public int ThreePointersAttempted { get; }
        public double ThreePointersPercentage { get; }

        public int FreeThrowsMade { get; }
        public int FreeThrowsAttempted { get; }
        public double FreeThrowsPercentage { get; }

        public int OffensiveRebounds { get; }
        public int DefensiveRebounds { get; }
        public int TotalRebounds { get; }

        public int Assists { get; }
        public int Steals { get; }
        public int Blocks { get; }
        public int Turnovers { get; }
        public int PersonalFouls { get; }
        public int Points { get; }
        public int PlusMinusScore { get; }

        public PlayerBoxScoreData(string playerName, bool starter, int secondsPlayed, int fieldGoalsMade, int fieldGoalsAttempted, int threePointersMade, int threePointersAttempted, int freeThrowsMade, int freeThrowsAttempted, int offensiveRebounds, int defensiveRebounds, int assists, int steals, int blocks, int turnovers, int personalFouls, int points, int plusMinusScore)
        {
            PlayerName = playerName;
            Starter = starter;

            SecondsPlayed += secondsPlayed;

            FieldGoalsMade = fieldGoalsMade;
            FieldGoalsAttempted = fieldGoalsAttempted;
            FieldGoalPercentage = Divide(fieldGoalsMade, fieldGoalsAttempted);

            ThreePointersMade = threePointersMade;
            ThreePointersAttempted = threePointersAttempted;
            ThreePointersPercentage = Divide(threePointersMade, threePointersAttempted);

            FreeThrowsMade = freeThrowsMade;
            FreeThrowsAttempted = freeThrowsAttempted;
            FreeThrowsPercentage = Divide(freeThrowsMade, freeThrowsAttempted);

            OffensiveRebounds = offensiveRebounds;
            DefensiveRebounds = defensiveRebounds;
            TotalRebounds = offensiveRebounds + defensiveRebounds;

            Assists = assists;
            Steals = steals;
            Blocks = blocks;
            Turnovers = turnovers;
            PersonalFouls = personalFouls;
            Points = points;
            
            PlusMinusScore = plusMinusScore;

            static double Divide(int left, int right, int decimals = 3) => right == 0 ? 0 : Math.Round((double)left / right, decimals);
        }

        public override string ToString()
        {
            return $"{PlayerName} - ({Points} points)";
        }
    }
}