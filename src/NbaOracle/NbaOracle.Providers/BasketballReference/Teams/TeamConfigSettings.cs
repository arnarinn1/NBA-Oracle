using BuildingBlocks.DocumentLoaders;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public class TeamConfigSettings
    {
        public TeamConfigSettings(string baseUrl, string directoryPath)
        {
            BaseUrl = $"{baseUrl}/teams";
            DirectoryPath = directoryPath;
        }

        public string BaseUrl { get; }
        public string DirectoryPath { get; }

        public DocumentOptions ToDocumentOptions(Team team, Season season)
        {
            var url = $"{BaseUrl}/{team.NameIdentifier}/{season.SeasonEndYear}.html";
            var directoryPath = $"{DirectoryPath}/html/teams/{season.SeasonStartYear}-{season.SeasonEndYear}";
            var filePath = $"{directoryPath}/{team.NameIdentifier}.json";
            return new DocumentOptions(url, directoryPath, filePath);
        }

        public (string directoryPath, string filePath) ToFileSystemPaths(Team team, Season season)
        {
            var directoryPath = $"{DirectoryPath}/output/teams/{season.SeasonStartYear}-{season.SeasonEndYear}";

            var filePath = $"{directoryPath}/{team.NameIdentifier}.json";

            return (directoryPath, filePath);
        }
    }
}