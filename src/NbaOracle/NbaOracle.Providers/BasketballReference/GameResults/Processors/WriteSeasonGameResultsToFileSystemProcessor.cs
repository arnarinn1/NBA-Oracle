using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.FileSystem;
using NbaOracle.Providers.BasketballReference.GameResults.Parsers.Games.Data;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameResults.Processors
{
    public class WriteSeasonGameResultsToFileSystemProcessor : ISeasonGameResultsProcessor
    {
        private readonly IFileSystem _fileSystem;
        private readonly SeasonGameResultsProcessorSettings _settings;

        public WriteSeasonGameResultsToFileSystemProcessor(IFileSystem fileSystem, SeasonGameResultsProcessorSettings settings)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public Task Process(Season season, IEnumerable<GameData> games)
        {
            var (directoryPath, filePath) = _settings.ToFileSystemPaths(season);

            _fileSystem.CreateDirectory(directoryPath);

            return _fileSystem.OverwriteFile(filePath, games);
        }
    }
}