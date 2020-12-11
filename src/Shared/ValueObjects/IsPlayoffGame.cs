using System;
using System.Collections.Generic;

namespace ValueObjects
{
    public class IsPlayoffGame : ValueObject
    {
        public bool Value { get; }
        public DateTime GameDate { get; }

        public IsPlayoffGame(DateTime gameDate)
        {
            GameDate = gameDate;
            Value = IsPlayoffGameCheck(gameDate);
        }

        public static implicit operator bool(IsPlayoffGame game) => game.Value;

        private static bool IsPlayoffGameCheck(DateTime gameDate)
        {
            switch (gameDate.Year)
            {
                case 2020:
                    return gameDate >= new DateTime(2020,08, 17) && gameDate <= new DateTime(2020, 10, 11);
                case 2019:
                    return gameDate >= new DateTime(2019, 4, 13) && gameDate <= new DateTime(2019, 6, 13);
                default:
                    throw new ArgumentException($"Playoff starting date is not known for year = {gameDate.Year}");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}