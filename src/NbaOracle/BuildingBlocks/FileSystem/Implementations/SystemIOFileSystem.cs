using System.Threading.Tasks;

namespace NbaOracle.Providers.BuildingBlocks.FileSystem.Implementations
{
    // ReSharper disable once InconsistentNaming
    public class SystemIOFileSystem : IFileSystem
    {
        public bool FileExists(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }

        public void CreateDirectory(string directoryPath)
        {
            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);
        }

        public Task CreateFile(string filePath, string content)
        {
            return System.IO.File.Exists(filePath)
                ? Task.CompletedTask
                : System.IO.File.WriteAllTextAsync(filePath, content);
        }

        public Task<string> LoadFileContents(string filePath)
        {
            return System.IO.File.ReadAllTextAsync(filePath);
        }
    }
}