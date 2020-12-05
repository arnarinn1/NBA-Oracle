using System.Threading.Tasks;
using AngleSharp;
using NbaOracle.Providers.BasketballReference;
using NbaOracle.Providers.BuildingBlocks.DocumentLoaders;
using NbaOracle.Providers.BuildingBlocks.DocumentLoaders.Implementations;
using NbaOracle.Providers.BuildingBlocks.FileSystem.Implementations;
using Xunit;

namespace NbaOracle.Tests
{
    public class TeamProviderTests
    {
        [Fact]
        public async Task Doo()
        {
            var url = "https://www.basketball-reference.com/teams/LAL/2020.html";
            var fileLocation = @"C:\Users\arnar.heimisson\Documents\Projects\Github\nba-data\seasons\2020";
            var identifier = "LAL";

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var fileSystem = new SystemIOFileSystem();

            var documentLoader = new AngleSharpHttpDocumentLoader(context);
            var validateBehavior = new ValidateDocumentHttpStatusBehavior(documentLoader);
            var writeBehavior = new WriteDocumentToFileSystemBehavior(validateBehavior, fileSystem);
            var cacheBehavior = new LoadDocumentFromFileSystemBehavior(writeBehavior, fileSystem, context);

            var provider = new TeamProvider(validateBehavior);
            await provider.DoStuff(new DocumentOptions(url, fileLocation, identifier));
        }
    }
}