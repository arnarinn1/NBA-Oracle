using System;
using ValueObjects;

namespace BuildingBlocks.FileSystem
{
    public class FileContent
    {
        public FileContent(string url, string directoryPath, string identifier, string content)
        {
            RetrievedTime = SystemTime.Now();
            Url = url;
            DirectoryPath = directoryPath;
            Identifier = identifier;
            Content = content;
        }

        public DateTime RetrievedTime { get; }
        public string Url { get; }
        public string DirectoryPath { get; }
        public string Identifier { get; }
        public string Content { get; }
    }
}