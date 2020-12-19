using BuildingBlocks.DocumentLoaders;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class GameDetailsConfigSettings
    {
        public GameDetailsConfigSettings(string baseUrl, string directoryPath)
        {
            BaseUrl = baseUrl;
            DirectoryPath = directoryPath;
        }

        public string BaseUrl { get; }
        public string DirectoryPath { get; }

        public DocumentOptions ToDocumentOptions(Season season, BoxScoreLink boxScoreLink)
        {
            var url = $"{BaseUrl}/{boxScoreLink.ToHtmlLink()}";
            var directoryPath = $"{DirectoryPath}/html/game-results/{season.SeasonStartYear}-{season.SeasonEndYear}/boxscores";
            var filePath = $"{directoryPath}/{boxScoreLink.GameId}.json";
            return new DocumentOptions(url, directoryPath, filePath);
        }

        public (string directoryPath, string filePath) ToFileSystemPaths(Season season, string gameId)
        {
            var directoryPath = $"{DirectoryPath}/output/game-results/{season.SeasonStartYear}-{season.SeasonEndYear}/box-score";

            var filePath = $"{directoryPath}/{gameId}.json";

            return (directoryPath, filePath);
        }
    }
}