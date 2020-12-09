using BuildingBlocks.DocumentLoaders;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public class TeamProviderSettings
    {
        public TeamProviderSettings(string baseUrl, string directoryPath)
        {
            BaseUrl = $"{baseUrl}/teams";
            DirectoryPath = $"{directoryPath}/html/teams";
        }

        public string BaseUrl { get; }
        public string DirectoryPath { get; }

        public DocumentOptions ToDocumentOptions(Team team, Season season)
        {
            var url = $"{BaseUrl}/{team.NameIdentifier}/{season.SeasonEndYear}.html";
            var directoryPath = $"{DirectoryPath}/{season.SeasonStartYear}-{season.SeasonEndYear}";
            var filePath = $"{directoryPath}/{team.NameIdentifier}.json";
            return new DocumentOptions(url, directoryPath, filePath);
        }
    }
}