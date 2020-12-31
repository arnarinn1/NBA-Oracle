namespace NbaOracle.Providers.StoredProcedureRequests.Teams.PlayerSeasonStatistics
{
    public class PlayerSeasonStatisticsSeasonRequestData
    {
        public class PlayerSeasonStatisticsData
        {
            public PlayerSeasonStatisticsData(int id, int playerId, int gamesPlayed, int minutesPlayed, double minutesPlayedPerGame, int fieldGoalsMade, int fieldGoalsAttempted, double fieldGoalPercentage, int threePointersMade, int threePointersAttempted, double threePointersPercentage, int twoPointersMade, int twoPointersAttempted, double twoPointersPercentage, double effectiveFieldGoalPercentage, int freeThrowsMade, int freeThrowsAttempted, double freeThrowsPercentage, int offensiveRebounds, int defensiveRebounds, int totalRebounds, double reboundsPerGame, int assists, double assistsPerGame, int steals, double stealsPerGame, int blocks, double blocksPerGame, int turnovers, double turnoversPerGame, int personalFouls, double personalFoulsPerGame, int points, double pointsPerGame)
            {
                Id = id;
                PlayerId = playerId;
                GamesPlayed = gamesPlayed;
                MinutesPlayed = minutesPlayed;
                MinutesPlayedPerGame = minutesPlayedPerGame;
                FieldGoalsMade = fieldGoalsMade;
                FieldGoalsAttempted = fieldGoalsAttempted;
                FieldGoalPercentage = fieldGoalPercentage;
                ThreePointersMade = threePointersMade;
                ThreePointersAttempted = threePointersAttempted;
                ThreePointersPercentage = threePointersPercentage;
                TwoPointersMade = twoPointersMade;
                TwoPointersAttempted = twoPointersAttempted;
                TwoPointersPercentage = twoPointersPercentage;
                EffectiveFieldGoalPercentage = effectiveFieldGoalPercentage;
                FreeThrowsMade = freeThrowsMade;
                FreeThrowsAttempted = freeThrowsAttempted;
                FreeThrowsPercentage = freeThrowsPercentage;
                OffensiveRebounds = offensiveRebounds;
                DefensiveRebounds = defensiveRebounds;
                TotalRebounds = totalRebounds;
                ReboundsPerGame = reboundsPerGame;
                Assists = assists;
                AssistsPerGame = assistsPerGame;
                Steals = steals;
                StealsPerGame = stealsPerGame;
                Blocks = blocks;
                BlocksPerGame = blocksPerGame;
                Turnovers = turnovers;
                TurnoversPerGame = turnoversPerGame;
                PersonalFouls = personalFouls;
                PersonalFoulsPerGame = personalFoulsPerGame;
                Points = points;
                PointsPerGame = pointsPerGame;
            }

            public int Id { get; }
            public int PlayerId { get; }

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

            public double EffectiveFieldGoalPercentage { get; }

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
        }
    }
}