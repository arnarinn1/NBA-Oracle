using BuildingBlocks.DocumentLoaders;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class GameDetailsProviderSettings
    {
        public GameDetailsProviderSettings(string baseUrl, string directoryPath)
        {
            BaseUrl = baseUrl;
            DirectoryPath = directoryPath;
        }

        public string BaseUrl { get; }
        public string DirectoryPath { get; }

        public DocumentOptions ToDocumentOptions(Season season, string boxScoreLink)
        {
            var url = $"{BaseUrl}/{boxScoreLink}";
            var directoryPath = $"{DirectoryPath}/{season.SeasonStartYear}-{season.SeasonEndYear}";
            var filePath = $"{directoryPath}/{boxScoreLink.Replace(".html", "")}.json";
            return new DocumentOptions(url, directoryPath, filePath);
        }
    }
}