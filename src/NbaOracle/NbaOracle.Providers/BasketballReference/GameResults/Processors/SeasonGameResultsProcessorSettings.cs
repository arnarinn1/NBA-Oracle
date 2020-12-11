using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameResults.Processors
{
    public class SeasonGameResultsProcessorSettings
    {
        public SeasonGameResultsProcessorSettings(string baseDirectory)
        {
            BaseDirectory = $"{baseDirectory}/output/game-results";
        }

        public string BaseDirectory { get; }

        public (string directoryPath, string filePath) ToFileSystemPaths(Season season)
        {
            var directoryPath = $"{BaseDirectory}/{season.SeasonStartYear}-{season.SeasonEndYear}";
            
            var filePath = $"{directoryPath}/games.json";

            return (directoryPath, filePath);
        }
    }
}