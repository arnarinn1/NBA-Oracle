using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams.Processors
{
    public class TeamProcessorFileSystemSettings
    {
        public TeamProcessorFileSystemSettings(string baseDirectory)
        {
            BaseDirectory = $"{baseDirectory}/output/teams";
        }

        public string BaseDirectory { get; }

        public (string directoryPath, string filePath) ToFileSystemPaths(Team team, Season season)
        {
            var directoryPath = $"{BaseDirectory}/{season.SeasonStartYear}-{season.SeasonEndYear}";

            var filePath = $"{directoryPath}/{team.NameIdentifier}.json";

            return (directoryPath, filePath);
        }
    }
}