using System;
using System.Collections.Generic;
using ValueObjects.Extensions;

namespace ValueObjects
{
    public class PlusMinusScore : ValueObject
    {
        public double Score { get; }

        public PlusMinusScore(string value)
        {
            _ = value.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(value));
            
            value = value.Trim();

            var sign = value.Substring(0, 1);
            var score = value.Substring(1, value.Length-1);

            Score = sign == "+"
                ? Math.Abs(ParsingMethods.ToDouble(score))
                : -Math.Abs(ParsingMethods.ToDouble(score));
        }

        public static implicit operator double(PlusMinusScore score) => score.Score;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Score;
        }
    }
}