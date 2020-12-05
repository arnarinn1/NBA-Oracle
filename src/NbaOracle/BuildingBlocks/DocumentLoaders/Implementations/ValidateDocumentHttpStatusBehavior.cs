using System;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Dom;
using NbaOracle.Providers.BuildingBlocks.DocumentLoaders.Extensions;

namespace NbaOracle.Providers.BuildingBlocks.DocumentLoaders.Implementations
{
    public class ValidateDocumentHttpStatusBehavior : IDocumentLoader
    {
        private readonly IDocumentLoader _next;

        public ValidateDocumentHttpStatusBehavior(IDocumentLoader next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task<IDocument> LoadDocument(DocumentOptions options)
        {
            var document = await _next.LoadDocument(options);

            if (!document.IsSuccessStatusCode())
                throw new HttpRequestException($"Request for url = '{document.Url}' returned status code = '{document.StatusCode}'");

            return document;
        }
    }
}