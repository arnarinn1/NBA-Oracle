using System;
using System.Threading.Tasks;
using BuildingBlocks.FileSystem;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public class LoadTeamDataFromFileSystemBehavior : ITeamProvider
    {
        private readonly ITeamProvider _next;
        private readonly IFileSystem _fileSystem;
        private readonly TeamConfigSettings _settings;

        public LoadTeamDataFromFileSystemBehavior(ITeamProvider next, IFileSystem fileSystem, TeamConfigSettings settings)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<TeamData> GetTeamData(Team team, Season season)
        {
            var (_, filePath) = _settings.ToFileSystemPaths(team, season);

            if (!_fileSystem.FileExists(filePath))
                return await _next.GetTeamData(team, season);

            return await _fileSystem.LoadFileContent<TeamData>(filePath);
        }
    }
}