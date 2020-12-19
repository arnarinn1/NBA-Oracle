using System;
using System.Threading.Tasks;
using BuildingBlocks.FileSystem;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details.Processors
{
    public class WriteGameDetailsToFileSystemProcessor : IGameDetailsProcessor
    {
        private readonly IFileSystem _fileSystem;
        private readonly GameDetailsConfigSettings _settings;

        public WriteGameDetailsToFileSystemProcessor(IFileSystem fileSystem, GameDetailsConfigSettings settings)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public Task Process(Season season, GameDetailsData gameDetails)
        {
            var (directoryPath, filePath) = _settings.ToFileSystemPaths(season, gameDetails.GameId);

            _fileSystem.CreateDirectory(directoryPath);

            return _fileSystem.OverwriteFile(filePath, gameDetails);
        }
    }
}