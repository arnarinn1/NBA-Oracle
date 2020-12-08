using System;
using System.Collections.Generic;

namespace ValueObjects
{
    public class Season : ValueObject
    {
        public int SeasonStartYear { get; }
        public int SeasonEndYear { get; }

        public int? CurrentYear { get; }

        public Season(int seasonStartYear, int? currentYear = null)
        {
            SeasonStartYear = seasonStartYear;
            SeasonEndYear = seasonStartYear + 1;

            if (currentYear == null)
                return;

            if (currentYear != SeasonStartYear && currentYear != SeasonEndYear)
                throw new ArgumentException("CurrentYear doesn't match season years");

            CurrentYear = currentYear;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SeasonEndYear;
        }
    }
}