namespace BuildingBlocks.DocumentLoaders
{
    public class DocumentOptions
    {
        public DocumentOptions(string url, string directoryPath, string identifier)
        {
            Url = url;
            DirectoryPath = directoryPath;
            Identifier = identifier;
        }

        public string Url { get; }
        public string DirectoryPath { get; }
        public string Identifier { get; }

        public string GetFilePath()
            => $"{DirectoryPath}/{Identifier}.json";
    }
}