using System;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data
{
    public class PlayerRoosterData
    {
        public static PlayerRoosterData Create(string name, string jerseyNumber, string position, DateTime birthDate, string birthCountry, string height, string weight, string yearsExperience, string college)
        {
            return new PlayerRoosterData(name, jerseyNumber, position, birthDate, birthCountry, new HeightInFeetAndInches(height).ToCm(), new WeightInPounds(weight).ToKiloGrams(), new NumberOfYearInLeague(yearsExperience), new College(college));
        }

        public PlayerRoosterData(string name, string jerseyNumber, string position, DateTime birthDate, string birthCountry, double height, double weight, int numberOfYearInLeague, string college)
        {
            Name = name;
            JerseyNumber = jerseyNumber;
            Position = position;
            BirthDate = birthDate;
            BirthCountry = birthCountry;
            Height = height;
            Weight = weight;
            NumberOfYearInLeague = numberOfYearInLeague;
            College = college;
        }

        public string Name { get; }
        public string JerseyNumber { get; }
        public string Position { get; }
        public DateTime BirthDate { get; }
        public string BirthCountry { get; }
        public double Height { get; }
        public double Weight { get; }
        public int NumberOfYearInLeague { get; }
        public string College { get; }

        public override string ToString() => $"{Name} ({Position}-{JerseyNumber})";
    }
}