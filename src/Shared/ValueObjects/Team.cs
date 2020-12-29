using System;
using System.Collections.Generic;
using ValueObjects.Extensions;

namespace ValueObjects
{
    public class Team : ValueObject
    {
        public string Name { get; }
        public string NameIdentifier { get; }

        public Team(string name, string nameIdentifier)
        {
            _ = name.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(name));
            _ = nameIdentifier.DiscardNullOrWhitespaceCheck() ?? throw new ArgumentNullException(nameof(nameIdentifier));

            Name = name;
            NameIdentifier = nameIdentifier.ToUpper();
        }

        public override string ToString() => NameIdentifier;

        public int GetIdentifier()
        {
            switch (NameIdentifier)
            {
                case "ATL": return 1;
                case "BOS": return 2;
                case "BRK": case "NJN": return 3;
                case "CHI": return 4;
                case "CHO": case "CHA": return 5;
                case "CLE": return 6;
                case "DAL": return 7;
                case "DEN": return 8;
                case "DET": return 9;
                case "GSW": return 10;
                case "HOU": return 11;
                case "IND": return 12;
                case "LAC": return 13;
                case "LAL": return 14;
                case "MEM": return 15;
                case "MIA": return 16;
                case "MIL": return 17;
                case "MIN": return 18;
                case "NOP": case "NOH": return 19;
                case "NYK": return 20;
                case "OKC": return 21;
                case "ORL": return 22;
                case "PHI": return 23;
                case "PHO": return 24;
                case "POR": return 25;
                case "SAC": return 26;
                case "SAS": return 27;
                case "TOR": return 28;
                case "UTA": return 29;
                case "WAS": return 30;
                default:
                    throw new ArgumentException($"Unknown NameIdentifier = {NameIdentifier}");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return NameIdentifier;
        }
    }
}