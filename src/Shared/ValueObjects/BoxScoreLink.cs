using System;
using System.Collections.Generic;
using ValueObjects.Extensions;

namespace ValueObjects
{
    public class BoxScoreLink : ValueObject
    {
        public string GameId { get; }

        public BoxScoreLink(string value)
        {
            _ = value.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(value));

            value = value.Trim();

            value = value.Replace(".html", "");

            if (!value.StartsWith("/boxscores/"))
                throw new ArgumentException("BoxScoreLink is not formatted correctly. Missing '/boxscores/' at the start of the string");

            GameId = value.Substring(11, value.Length - 11);
        }

        public string ToHtmlLink() => $"boxscores/{GameId}.html";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return GameId;
        }
    }
}