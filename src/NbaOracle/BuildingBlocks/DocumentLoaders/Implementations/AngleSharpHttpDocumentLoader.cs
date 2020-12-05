using System;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace NbaOracle.Providers.BuildingBlocks.DocumentLoaders.Implementations
{
    public class AngleSharpHttpDocumentLoader : IDocumentLoader
    {
        private readonly IBrowsingContext _browsingContext;

        public AngleSharpHttpDocumentLoader(IBrowsingContext browsingContext)
        {
            _browsingContext = browsingContext ?? throw new ArgumentNullException(nameof(browsingContext));
        }

        public Task<IDocument> LoadDocument(DocumentOptions options)
        {
            return _browsingContext.OpenAsync(options.Url);
        }
    }
}