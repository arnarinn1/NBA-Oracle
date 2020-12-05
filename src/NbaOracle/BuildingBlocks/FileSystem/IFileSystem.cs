using System.Threading.Tasks;

namespace NbaOracle.Providers.BuildingBlocks.FileSystem
{
    public interface IFileSystem
    {
        bool FileExists(string filePath);
        void CreateDirectory(string directoryPath);
        Task CreateFile(string filePath, string content); //todo -> pass in an object
        
        Task<string> LoadFileContents(string filePath);
    }
}