namespace BuildingBlocks.DocumentLoaders
{
    public class DocumentOptions
    {
        public DocumentOptions(string url, string directoryPath, string filePath)
        {
            Url = url;
            DirectoryPath = directoryPath;
            FilePath = filePath;
        }

        public string Url { get; }
        public string DirectoryPath { get; }
        public string FilePath { get; }
    }
}