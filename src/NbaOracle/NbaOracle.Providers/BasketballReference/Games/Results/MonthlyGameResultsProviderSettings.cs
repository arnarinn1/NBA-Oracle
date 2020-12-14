using BuildingBlocks.DocumentLoaders;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Results
{
    public class MonthlyGameResultsProviderSettings
    {
        public MonthlyGameResultsProviderSettings(string baseUrl, string directoryPath)
        {
            BaseUrl = $"{baseUrl}/leagues";
            DirectoryPath = $"{directoryPath}/html/game-results";
        }

        public string BaseUrl { get; }
        public string DirectoryPath { get; }

        public DocumentOptions ToDocumentOptions(Season season, Month month)
        {
            var url = month.IsOctoberDuringEither2019Or2020()
                ? $"{BaseUrl}/NBA_{season.SeasonEndYear}_games-{month.ToLower()}-{month.Year}.html"
                : $"{BaseUrl}/NBA_{season.SeasonEndYear}_games-{month.ToLower()}.html";
            
            var directoryPath = $"{DirectoryPath}/{season.SeasonStartYear}-{season.SeasonEndYear}";
            var filePath = $"{directoryPath}/{month.Year}-{month.ToLower()}.json";

            return new DocumentOptions(url, directoryPath, filePath);
        }
    }
}