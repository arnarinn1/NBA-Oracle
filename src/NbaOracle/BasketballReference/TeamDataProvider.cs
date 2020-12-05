using System;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster;

namespace NbaOracle.Providers.BasketballReference
{
    public class TeamDataProvider
    {
        private readonly IDocumentLoader _documentLoader;
        
        private readonly TeamRoosterParser _parser;

        public TeamDataProvider(IDocumentLoader documentLoader)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _parser = new TeamRoosterParser();
        }

        public async Task DoStuff(DocumentOptions documentOptions)
        {
            var document = await _documentLoader.LoadDocument(documentOptions);

            var output = _parser.Parse(document);
        }
    }
}