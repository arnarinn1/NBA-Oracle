using System;
using System.Linq;
using System.Threading.Tasks;
using NbaOracle.Providers.BuildingBlocks.DocumentLoaders;

namespace NbaOracle.Providers.BasketballReference
{
    public class TeamProvider
    {
        private readonly IDocumentLoader _documentLoader;

        public TeamProvider(IDocumentLoader documentLoader)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
        }

        public async Task DoStuff(DocumentOptions documentOptions)
        {
            var document = await _documentLoader.LoadDocument(documentOptions);
            var foo = document.All.Where(x => x.LocalName == "div" && x.HasAttribute("id") && x.GetAttribute("id") == "all_roster");
        }
    }
}