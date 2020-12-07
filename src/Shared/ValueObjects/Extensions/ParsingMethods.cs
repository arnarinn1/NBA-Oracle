using System;
using System.Globalization;

namespace ValueObjects.Extensions
{
    public static class ParsingMethods
    {
        public static int ToInt(string value)
        {
            if (int.TryParse(value, out var result))
                return result;

            throw new FormatException($"Unable to format string to int. ({value})");
        }

        public static DateTime ToDate(string value, string format)
        {
            if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                return result;

            throw new FormatException($"Unable to format string to int. ({value})");
        }
    }
}