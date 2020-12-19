using System;
using System.Threading.Tasks;
using BuildingBlocks.FileSystem;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public class LoadGameDetailsFromFileSystemBehavior : IGameDetailsProvider
    {
        private readonly IGameDetailsProvider _next;
        private readonly IFileSystem _fileSystem;
        private readonly GameDetailsConfigSettings _settings;

        public LoadGameDetailsFromFileSystemBehavior(IGameDetailsProvider next, IFileSystem fileSystem, GameDetailsConfigSettings settings)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<GameDetailsData> GetGameDetails(Season season, BoxScoreLink boxScoreLink)
        {
            var (_, filePath) = _settings.ToFileSystemPaths(season, boxScoreLink.GameId);
            
            if (!_fileSystem.FileExists(filePath))
                return await _next.GetGameDetails(season, boxScoreLink);

            return await _fileSystem.LoadFileContent<GameDetailsData>(filePath);
        }
    }
}