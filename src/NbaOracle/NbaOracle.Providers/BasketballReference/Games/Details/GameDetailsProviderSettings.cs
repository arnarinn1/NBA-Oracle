using BuildingBlocks.DocumentLoaders;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class GameDetailsProviderSettings
    {
        public GameDetailsProviderSettings(string baseUrl, string directoryPath)
        {
            BaseUrl = baseUrl;
            DirectoryPath = $"{directoryPath}/html/game-results";
        }

        public string BaseUrl { get; }
        public string DirectoryPath { get; }

        public DocumentOptions ToDocumentOptions(Season season, BoxScoreLink boxScoreLink)
        {
            var url = $"{BaseUrl}/{boxScoreLink.ToHtmlLink()}";
            var directoryPath = $"{DirectoryPath}/{season.SeasonStartYear}-{season.SeasonEndYear}/boxscores";
            var filePath = $"{directoryPath}/{boxScoreLink.GameId}.json";
            return new DocumentOptions(url, directoryPath, filePath);
        }
    }
}