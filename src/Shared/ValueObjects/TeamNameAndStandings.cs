using System;
using System.Collections.Generic;
using ValueObjects.Extensions;

namespace ValueObjects
{
    public class TeamNameAndStandings : ValueObject
    {
        public string TeamName { get; }
        public int Wins { get; }
        public int Losses { get; }

        public TeamNameAndStandings(string value)
        {
            _ = value.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(value));

            value = value.Trim();

            var firstIndexOfBracket = value.IndexOf("(", StringComparison.InvariantCulture);
            var lastIndexOfBracket = value.LastIndexOf(")", StringComparison.InvariantCulture);

            TeamName = value.Substring(0, firstIndexOfBracket-1);

            var winsAndLosses = value.Substring(firstIndexOfBracket + 1, lastIndexOfBracket - firstIndexOfBracket - 1);
            
            var split = winsAndLosses.Split("-");
            if (split.Length != 2)
                throw new ArgumentException("TeamNameAndStandings is not formatted correctly");

            Wins = ParsingMethods.ToInt(split[0]);
            Losses = ParsingMethods.ToInt(split[1]);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TeamName;
            yield return Losses;
            yield return TeamName;
        }
    }
}