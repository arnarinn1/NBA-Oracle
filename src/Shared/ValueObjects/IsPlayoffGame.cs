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
                    return gameDate >= new DateTime(2020, 8, 17) && gameDate <= new DateTime(2020, 10, 11);
                case 2019:
                    return gameDate >= new DateTime(2019, 4, 13) && gameDate <= new DateTime(2019, 6, 13);
                case 2018:
                    return gameDate >= new DateTime(2018, 4, 14) && gameDate <= new DateTime(2018, 6, 8);
                case 2017:
                    return gameDate >= new DateTime(2017, 4, 15) && gameDate <= new DateTime(2017, 6, 12);
                case 2016:
                    return gameDate >= new DateTime(2016, 4, 16) && gameDate <= new DateTime(2016, 6, 19);
                case 2015:
                    return gameDate >= new DateTime(2015, 4, 18) && gameDate <= new DateTime(2015, 6, 16);
                case 2014:
                    return gameDate >= new DateTime(2014, 4, 19) && gameDate <= new DateTime(2014, 6, 15);
                case 2013:
                    return gameDate >= new DateTime(2013, 4, 20) && gameDate <= new DateTime(2013, 6, 20);
                case 2012:
                    return gameDate >= new DateTime(2012, 4, 28) && gameDate <= new DateTime(2012, 6, 21);
                case 2011:
                    return gameDate >= new DateTime(2011, 4, 16) && gameDate <= new DateTime(2011, 6, 12);
                case 2010:
                    return gameDate >= new DateTime(2010, 4, 17) && gameDate <= new DateTime(2010, 6, 17);
                case 2009:
                    return gameDate >= new DateTime(2009, 4, 18) && gameDate <= new DateTime(2009, 6, 14);
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