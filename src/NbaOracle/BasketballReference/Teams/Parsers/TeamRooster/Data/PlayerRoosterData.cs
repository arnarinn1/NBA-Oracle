namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data
{
    public class PlayerRoosterData
    {
        public PlayerRoosterData(string name, string jerseyNumber, string position, string birthDate, string birthCountry, string height, string weight, string yearsExperience, string college)
        {
            Name = name;
            JerseyNumber = jerseyNumber;
            Position = position;
            BirthDate = birthDate;
            BirthCountry = birthCountry;
            Height = height;
            Weight = weight;
            YearsExperience = yearsExperience;
            College = string.IsNullOrWhiteSpace(college) ? "High School" : college;
        }

        public string Name { get; }
        public string JerseyNumber { get; }
        public string Position { get; }
        public string BirthDate { get; }
        public string BirthCountry { get; }
        public string Height { get; }
        public string Weight { get; }
        public string YearsExperience { get; }
        public string College { get; }

        public override string ToString() => $"{Name} ({Position}-{JerseyNumber})";
    }
}