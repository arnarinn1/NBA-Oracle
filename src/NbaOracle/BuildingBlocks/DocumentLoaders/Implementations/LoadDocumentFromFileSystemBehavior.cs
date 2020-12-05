﻿using System;
using System.Net;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using NbaOracle.Providers.BuildingBlocks.FileSystem;

namespace NbaOracle.Providers.BuildingBlocks.DocumentLoaders.Implementations
{
    public class LoadDocumentFromFileSystemBehavior : IDocumentLoader
    {
        private readonly IDocumentLoader _next;
        private readonly IFileSystem _fileSystem;
        private readonly IBrowsingContext _browsingContext;

        public LoadDocumentFromFileSystemBehavior(IDocumentLoader next, IFileSystem fileSystem, IBrowsingContext browsingContext)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _browsingContext = browsingContext ?? throw new ArgumentNullException(nameof(browsingContext));
        }

        public async Task<IDocument> LoadDocument(DocumentOptions options)
        {
            var filePath = options.GetFilePath();
            if (!_fileSystem.FileExists(filePath)) 
                return await _next.LoadDocument(options);

            var content = await _fileSystem.LoadFileContents(filePath);
            
            return await _browsingContext.OpenAsync(request =>
            {
                request.Address(options.Url);
                request.Content(content);
                request.Status(HttpStatusCode.OK);
            });
        }
    }
}