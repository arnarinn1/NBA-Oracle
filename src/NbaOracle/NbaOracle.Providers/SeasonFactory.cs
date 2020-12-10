using System.Collections.Generic;
using ValueObjects;

namespace NbaOracle.Providers
{
    public class SeasonFactory
    {
        public IReadOnlyList<Month> GetMonthsInSeason(Season season)
        {
            if (season == new Season(2019))
                return new List<Month> {Month.October(), Month.November(), Month.December(), Month.January(), Month.February(), Month.March(), Month.July(), Month.August(), Month.September(), Month.October()};

            if (season == new Season(2011))
                return new List<Month> { Month.December(), Month.January(), Month.February(), Month.March(), Month.April(), Month.May(), Month.June() };

            return new List<Month> { Month.October(), Month.November(), Month.December(), Month.January(), Month.February(), Month.March(), Month.April(), Month.May(), Month.June() };
        }
    }
}