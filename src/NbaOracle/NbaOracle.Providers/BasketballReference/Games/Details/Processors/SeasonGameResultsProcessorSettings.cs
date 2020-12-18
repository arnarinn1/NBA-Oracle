using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details.Processors
{
    public class GameDetailsProcessorSettings
    {
        public GameDetailsProcessorSettings(string baseDirectory)
        {
            BaseDirectory = $"{baseDirectory}/output/game-results";
        }

        public string BaseDirectory { get; }

        public (string directoryPath, string filePath) ToFileSystemPaths(Season season, string gameId)
        {
            var directoryPath = $"{BaseDirectory}/{season.SeasonStartYear}-{season.SeasonEndYear}/box-score";

            var filePath = $"{directoryPath}/{gameId}.json";

            return (directoryPath, filePath);
        }
    }
}