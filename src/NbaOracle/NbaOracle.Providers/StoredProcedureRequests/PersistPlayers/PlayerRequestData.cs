using System;

namespace NbaOracle.Providers.StoredProcedureRequests.PersistPlayers
{
    public class PlayerRequestData
    {
        public PlayerRequestData(string identifier, string name, DateTime birthDate, string birthCountry, string college)
        {
            Identifier = identifier;
            Name = name;
            BirthDate = birthDate;
            BirthCountry = birthCountry;
            College = college;
        }

        public string Identifier { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthCountry { get; set; }
        public string College { get; set; }
    }
}