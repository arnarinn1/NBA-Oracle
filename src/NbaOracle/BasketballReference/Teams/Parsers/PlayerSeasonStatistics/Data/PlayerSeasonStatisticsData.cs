using System;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics.Data
{
    public class PlayerSeasonStatisticsData
    {
        public string PlayerName { get; }
        
        public int GamesPlayed { get; }
        public int MinutesPlayed { get; }
        public double MinutesPlayedPerGame { get; }
        
        public int FieldGoalsMade { get; }
        public int FieldGoalsAttempted { get; }
        public double FieldGoalPercentage { get; }

        public int ThreePointersMade { get; }
        public int ThreePointersAttempted { get; }
        public double ThreePointersPercentage { get; }

        public int TwoPointersMade { get; }
        public int TwoPointersAttempted { get; }
        public double TwoPointersPercentage { get; }

        public string EffectiveFieldGoalPercentage { get; }
        
        public int FreeThrowsMade { get; }
        public int FreeThrowsAttempted { get; }
        public double FreeThrowsPercentage { get; }

        public int OffensiveRebounds { get; }
        public int DefensiveRebounds { get; }
        public int TotalRebounds { get; }
        public double ReboundsPerGame { get; }

        public int Assists { get; }
        public double AssistsPerGame { get; }

        public int Steals { get; }
        public double StealsPerGame { get; }

        public int Blocks { get; }
        public double BlocksPerGame { get; }

        public int Turnovers { get; }
        public double TurnoversPerGame { get; }

        public int PersonalFouls { get; }
        public double PersonalFoulsPerGame { get; }

        public int Points { get; }
        public double PointsPerGame { get; }

        public PlayerSeasonStatisticsData(string playerName, int gamesPlayed, int minutesPlayed, int fieldGoalsMade, int fieldGoalsAttempted, int threePointersMade, int threePointersAttempted, int twoPointersMade, int twoPointersAttempted, string effectiveFieldGoalPercentage, int freeThrowsMade, int freeThrowsAttempted, int offensiveRebounds, int defensiveRebounds, int assists, int  steals, int blocks, int turnovers, int personalFouls, int points)
        {
            PlayerName = playerName;
            
            GamesPlayed = gamesPlayed;
            MinutesPlayed = minutesPlayed;
            MinutesPlayedPerGame = Divide(minutesPlayed, gamesPlayed,1);
            
            FieldGoalsMade = fieldGoalsMade;
            FieldGoalsAttempted = fieldGoalsAttempted;
            FieldGoalPercentage = Divide(fieldGoalsMade, fieldGoalsAttempted);

            ThreePointersMade = threePointersMade;
            ThreePointersAttempted = threePointersAttempted;
            ThreePointersPercentage = Divide(threePointersMade, threePointersAttempted);

            TwoPointersMade = twoPointersMade;
            TwoPointersAttempted = twoPointersAttempted;
            TwoPointersPercentage = Divide(twoPointersMade, twoPointersAttempted);

            EffectiveFieldGoalPercentage = effectiveFieldGoalPercentage;
            
            FreeThrowsMade = freeThrowsMade;
            FreeThrowsAttempted = freeThrowsAttempted;
            FreeThrowsPercentage = Divide(freeThrowsMade, freeThrowsAttempted);
            
            OffensiveRebounds = offensiveRebounds;
            DefensiveRebounds = defensiveRebounds;
            TotalRebounds = offensiveRebounds + defensiveRebounds;
            ReboundsPerGame = Divide(TotalRebounds, gamesPlayed, 1);

            Assists = assists;
            AssistsPerGame = Divide(assists, gamesPlayed, 1);

            Steals = steals;
            StealsPerGame = Divide(steals, gamesPlayed, 1);

            Blocks = blocks;
            BlocksPerGame = Divide(blocks, gamesPlayed, 1);

            Turnovers = turnovers;
            TurnoversPerGame = Divide(turnovers, gamesPlayed, 1);

            PersonalFouls = personalFouls;
            PersonalFoulsPerGame = Divide(personalFouls, gamesPlayed, 1);

            Points = points;
            PointsPerGame = Divide(points, gamesPlayed, 1);

            static double Divide(int left, int right, int decimals = 3) => Math.Round((double)left / right, decimals);
        }

        public override string ToString()
        {
            return $"{PlayerName} - ({Points} points)";
        }
    }
}