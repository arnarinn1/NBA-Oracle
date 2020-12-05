using System;
using System.Threading.Tasks;
using AngleSharp.Dom;
using BuildingBlocks.FileSystem;

namespace BuildingBlocks.DocumentLoaders.Implementations
{
    public class WriteDocumentToFileSystemBehavior : IDocumentLoader
    {
        private readonly IDocumentLoader _next;
        private readonly IFileSystem _fileSystem;

        public WriteDocumentToFileSystemBehavior(IDocumentLoader next, IFileSystem fileSystem)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public async Task<IDocument> LoadDocument(DocumentOptions options)
        {
            var document = await _next.LoadDocument(options);

            _fileSystem.CreateDirectory(options.DirectoryPath);

            await _fileSystem.CreateFile(options.GetFilePath(), new FileContent(options.Url, options.DirectoryPath, options.Identifier, document.Source.Text));

            return document;
        }
    }
}