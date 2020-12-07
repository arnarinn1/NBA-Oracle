using System;
using System.Collections.Generic;
using ValueObjects.Extensions;

namespace ValueObjects
{
    public class WeightInPounds : ValueObject
    {
        public int Value { get; }

        public WeightInPounds(string value)
        {
            _ = value.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(value));

            Value = ParsingMethods.ToInt(value);
        }

        public double ToKiloGrams()
        {
            return Math.Round(Value * 0.453592, 2);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}