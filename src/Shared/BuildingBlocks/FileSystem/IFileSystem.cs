using System.Threading.Tasks;

namespace BuildingBlocks.FileSystem
{
    public interface IFileSystem
    {
        bool FileExists(string filePath);
        void CreateDirectory(string directoryPath);
        Task CreateFile(string filePath, FileContent content);
        Task OverwriteFile<T>(string filePath, T data);
        Task<FileContent> LoadFileContent(string filePath);
    }
}