namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics.Data
{
    public class PlayerSeasonStatisticsData
    {
        public string PlayerName { get; }
        public string GamesPlayed { get; }
        public string MinutesPlayed { get; }
        public string FieldGoalsMade { get; }
        public string FieldGoalsAttempted { get; }
        public string ThreePointersMade { get; }
        public string ThreePointersAttempted { get; }
        public string TwoPointersMade { get; }
        public string TwoPointersAttempted { get; }
        public string EffectiveFieldGoalPercentage { get; }
        public string FreeThrowsMade { get; }
        public string FreeThrowsAttempted { get; }
        public string OffensiveRebounds { get; }
        public string DefensiveRebounds { get; }
        public string Assists { get; }
        public string Steals { get; }
        public string Blocks { get; }
        public string Turnovers { get; }
        public string PersonalFouls { get; }
        public string Points { get; }

        public PlayerSeasonStatisticsData(string playerName, string gamesPlayed, string minutesPlayed, string fieldGoalsMade, string fieldGoalsAttempted, string threePointersMade, string threePointersAttempted, string twoPointersMade, string twoPointersAttempted, string effectiveFieldGoalPercentage, string freeThrowsMade, string freeThrowsAttempted, string offensiveRebounds, string defensiveRebounds, string assists, string steals, string blocks, string turnovers, string personalFouls, string points)
        {
            PlayerName = playerName;
            GamesPlayed = gamesPlayed;
            MinutesPlayed = minutesPlayed;
            FieldGoalsMade = fieldGoalsMade;
            FieldGoalsAttempted = fieldGoalsAttempted;
            ThreePointersMade = threePointersMade;
            ThreePointersAttempted = threePointersAttempted;
            TwoPointersMade = twoPointersMade;
            TwoPointersAttempted = twoPointersAttempted;
            EffectiveFieldGoalPercentage = effectiveFieldGoalPercentage;
            FreeThrowsMade = freeThrowsMade;
            FreeThrowsAttempted = freeThrowsAttempted;
            OffensiveRebounds = offensiveRebounds;
            DefensiveRebounds = defensiveRebounds;
            Assists = assists;
            Steals = steals;
            Blocks = blocks;
            Turnovers = turnovers;
            PersonalFouls = personalFouls;
            Points = points;
        }

        public override string ToString()
        {
            return $"{PlayerName} - ({Points} points)";
        }
    }
}