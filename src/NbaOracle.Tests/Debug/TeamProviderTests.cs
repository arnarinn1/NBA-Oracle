using System;
using System.Threading.Tasks;
using AngleSharp;
using BuildingBlocks.DocumentLoaders.Implementations;
using BuildingBlocks.FileSystem.Implementations;
using BuildingBlocks.Serialization.Implementation;
using NbaOracle.Providers;
using NbaOracle.Providers.BasketballReference.Teams;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Debug
{
    public class TeamProviderTests
    {
        [Fact]
        public async Task Execute()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var serializer = new NativeJsonSerializer();
            var fileSystem = new SystemIOFileSystem(serializer);

            var providerSettings = new TeamProviderSettings("https://www.basketball-reference.com/teams", @"C:\Users\arnar.heimisson\Documents\Projects\Github\nba-data\html\seasons");

            var documentLoader = new AngleSharpHttpDocumentLoader(context);
            var validateBehavior = new ValidateDocumentHttpStatusBehavior(documentLoader);
            var writeBehavior = new WriteDocumentToFileSystemBehavior(validateBehavior, fileSystem);
            var cacheBehavior = new LoadDocumentFromFileSystemBehavior(writeBehavior, fileSystem, context);
            
            var provider = new TeamProvider(cacheBehavior, providerSettings);

            await provider.GetTeamData(TeamsFactory.GetTeam("LAL"), new SeasonIdentifier(2019));

            //foreach (var team in TeamsFactory.Teams)
            //{
            //    await provider.GetTeamData(team.Value, new SeasonIdentifier(2019));

            //    await Task.Delay(TimeSpan.FromSeconds(2));
            //}
        }
    }
}