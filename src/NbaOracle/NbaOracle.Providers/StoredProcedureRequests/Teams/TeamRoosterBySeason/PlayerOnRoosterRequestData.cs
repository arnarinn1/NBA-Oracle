namespace NbaOracle.Providers.StoredProcedureRequests.Teams.TeamRoosterBySeason
{
    public class PlayerOnRoosterRequestData
    {
        public PlayerOnRoosterRequestData(int teamBySeasonId, int playerId, string jerseyNumber, string position, double height, double weight, int numberOfYearInLeague)
        {
            TeamBySeasonId = teamBySeasonId;
            PlayerId = playerId;
            JerseyNumber = jerseyNumber;
            Position = position;
            Height = height;
            Weight = weight;
            NumberOfYearInLeague = numberOfYearInLeague;
        }

        public int TeamBySeasonId { get; } 
        public int PlayerId { get; }

        public string JerseyNumber { get; }
        public string Position { get; }

        public double Height { get; }
        public double Weight { get; }

        public int NumberOfYearInLeague { get; }
    }
}