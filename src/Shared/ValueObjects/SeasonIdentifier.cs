using System.Collections.Generic;

namespace ValueObjects
{
    public class SeasonIdentifier : ValueObject
    {
        public int SeasonStartYear { get; }
        public int SeasonEndYear { get; }

        public SeasonIdentifier(int seasonStartYear)
        {
            SeasonStartYear = seasonStartYear;
            SeasonEndYear = seasonStartYear + 1;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SeasonEndYear;
        }
    }
}