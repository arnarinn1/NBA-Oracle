using System;
using System.Collections.Generic;
using System.Linq;
using ValueObjects.Extensions;

namespace ValueObjects
{
    public class Month : ValueObject
    {
        public string Value { get; }

        private static readonly IReadOnlyList<string> Months =
            new[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };

        public Month(string value)
        {
            _ = value.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(value));

            value = value.Trim();

            if (!Months.Contains(value))
                throw new ArgumentOutOfRangeException(nameof(value), $"Value '{value}' is not a valid month");

            Value = value;
        }

        public string ToLower()
        {
            return Value.ToLower();
        }

        public static Month January() => new Month("January");
        public static Month February() => new Month("February");
        public static Month March() => new Month("March");
        public static Month April() => new Month("April");
        public static Month May() => new Month("May");
        public static Month June() => new Month("June");
        public static Month July() => new Month("July");
        public static Month August() => new Month("August");
        public static Month September() => new Month("September");
        public static Month October() => new Month("October");
        public static Month November() => new Month("November");
        public static Month December() => new Month("December");

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}