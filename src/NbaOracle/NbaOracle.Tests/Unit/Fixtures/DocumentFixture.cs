using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace NbaOracle.Tests.Unit.Fixtures
{
    public class DocumentFixture : IDisposable
    {
        public async Task<IDocument> CreateDocument(string resource)
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var content = await ReadEmbeddedResource(resource);
            return await context.OpenAsync(request => request.Content(content));
        }

        private async Task<string> ReadEmbeddedResource(string name)
        {
            var resourceStream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(name);

            if (resourceStream == null)
                throw new FileNotFoundException($"Embedded resource not found for name = {name}");

            using var reader = new StreamReader(resourceStream);
            return await reader.ReadToEndAsync();
        }

        public void Dispose() { }
    }
}