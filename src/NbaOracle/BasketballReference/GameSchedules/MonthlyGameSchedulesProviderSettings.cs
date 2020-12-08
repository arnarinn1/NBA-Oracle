using BuildingBlocks.DocumentLoaders;
using ValueObjects;
// ReSharper disable PossibleInvalidOperationException

namespace NbaOracle.Providers.BasketballReference.GameSchedules
{
    public class MonthlyGameSchedulesProviderSettings
    {
        public MonthlyGameSchedulesProviderSettings(string baseUrl, string directoryPath)
        {
            BaseUrl = baseUrl;
            DirectoryPath = directoryPath;
        }

        public string BaseUrl { get; }
        public string DirectoryPath { get; }

        public DocumentOptions ToDocumentOptions(Season season, Month month)
        {
            if (season == new Season(2019) && month == Month.October())
                return WhenItsOctoberAnd2020Season(season, month);

            var url = $"{BaseUrl}/NBA_{season.SeasonEndYear}_games-{month.ToLower()}.html";
            var directoryPath = $"{DirectoryPath}/{season.SeasonStartYear}-{season.SeasonEndYear}";
            var filePath = $"{directoryPath}/{month.ToLower()}.json";

            return new DocumentOptions(url, directoryPath, filePath);
        }

        private DocumentOptions WhenItsOctoberAnd2020Season(Season season, Month month)
        {
            var url = $"{BaseUrl}/NBA_{season.SeasonEndYear}_games-{month.ToLower()}-{season.SeasonStartYear}.html";
            var directoryPath = $"{DirectoryPath}/{season.SeasonStartYear}-{season.SeasonEndYear}";
            var filePath = $"{directoryPath}/{month.ToLower()}-{season.CurrentYear.Value}.json";
            
            return new DocumentOptions(url, directoryPath, filePath);
        }
    }
}