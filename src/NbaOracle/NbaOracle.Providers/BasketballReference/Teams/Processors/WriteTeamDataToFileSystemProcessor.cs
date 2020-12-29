using System;
using System.Threading.Tasks;
using BuildingBlocks.FileSystem;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams.Processors
{
    public class WriteTeamDataToFileSystemProcessor : ITeamProcessor
    {
        private readonly IFileSystem _fileSystem;
        private readonly TeamConfigSettings _settings;

        public WriteTeamDataToFileSystemProcessor(IFileSystem fileSystem, TeamConfigSettings settings)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public Task Process(Team team, Season season, TeamData teamData)
        {
            var (directoryPath, filePath) = _settings.ToFileSystemPaths(team, season);

            _fileSystem.CreateDirectory(directoryPath);

            return _fileSystem.OverwriteFile(filePath, teamData);
        }
    }
}