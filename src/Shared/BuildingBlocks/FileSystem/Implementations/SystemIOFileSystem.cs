using System;
using System.Threading.Tasks;
using BuildingBlocks.Serialization;

namespace BuildingBlocks.FileSystem.Implementations
{
    // ReSharper disable once InconsistentNaming
    public class SystemIOFileSystem : IFileSystem
    {
        private readonly ISerializer _serializer;

        public SystemIOFileSystem(ISerializer serializer)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public bool FileExists(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }

        public void CreateDirectory(string directoryPath)
        {
            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);
        }

        public Task CreateFile(string filePath, FileContent content)
        {
            return System.IO.File.Exists(filePath)
                ? Task.CompletedTask
                : System.IO.File.WriteAllTextAsync(filePath, _serializer.Serialize(content));
        }

        public async Task<FileContent> LoadFileContent(string filePath)
        {
            var content = await System.IO.File.ReadAllTextAsync(filePath);
            return _serializer.Deserialize<FileContent>(content);
        }
    }
}