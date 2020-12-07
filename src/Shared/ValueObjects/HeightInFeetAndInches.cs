using System;
using System.Collections.Generic;
using ValueObjects.Extensions;

namespace ValueObjects
{
    public class HeightInFeetAndInches : ValueObject
    {
        public string Value { get; }

        private readonly int _feet;
        private readonly int _inches;

        public HeightInFeetAndInches(string value)
        {
            _ = value.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(value));

            value = value.Trim();

            var split = value.Split("-");

            if (split.Length != 2)
                throw new ArgumentException("Height in feet and inches is incorrectly formatted");

            _feet = ParsingMethods.ToInt(split[0]);
            _inches = ParsingMethods.ToInt(split[1]);

            Value = value;
        }

        public double ToCm()
        {
            var conversion = (_feet + _inches / 12.0) * 30.48;
            return Math.Round(conversion, 2);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}