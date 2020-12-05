using System.Threading.Tasks;
using AngleSharp;
using BuildingBlocks.DocumentLoaders;
using BuildingBlocks.DocumentLoaders.Implementations;
using BuildingBlocks.FileSystem.Implementations;
using BuildingBlocks.Serialization.Implementation;
using NbaOracle.Providers.BasketballReference;
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

            var serializer = new NativeJsonSerializer();
            var fileSystem = new SystemIOFileSystem(serializer);

            var documentLoader = new AngleSharpHttpDocumentLoader(context);
            var validateBehavior = new ValidateDocumentHttpStatusBehavior(documentLoader);
            var writeBehavior = new WriteDocumentToFileSystemBehavior(validateBehavior, fileSystem);
            var cacheBehavior = new LoadDocumentFromFileSystemBehavior(writeBehavior, fileSystem, context);

            var provider = new TeamDataProvider(cacheBehavior);
            await provider.DoStuff(new DocumentOptions(url, fileLocation, identifier));
        }
    }
}