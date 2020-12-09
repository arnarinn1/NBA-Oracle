using System.Threading.Tasks;
using AngleSharp;
using BuildingBlocks.DocumentLoaders.Implementations;
using BuildingBlocks.FileSystem.Implementations;
using BuildingBlocks.Serialization.Implementation;
using NbaOracle.Providers.BasketballReference.GameSchedules;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Debug
{
    public class MonthlyGameSchedulesProviderTests
    {
        [Fact]
        public async Task Execute()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var serializer = new NativeJsonSerializer();
            var fileSystem = new SystemIOFileSystem(serializer);

            var providerSettings = new MonthlyGameSchedulesProviderSettings("https://www.basketball-reference.com/leagues", @"C:\Users\arnar.heimisson\Documents\Projects\Github\nba-data\html\schedule");

            var documentLoader = new AngleSharpHttpDocumentLoader(context);
            var validateBehavior = new ValidateDocumentHttpStatusBehavior(documentLoader);
            var writeBehavior = new WriteDocumentToFileSystemBehavior(validateBehavior, fileSystem);
            var cacheBehavior = new LoadDocumentFromFileSystemBehavior(writeBehavior, fileSystem, context);

            var provider = new MonthlyGameSchedulesProvider(cacheBehavior, providerSettings);

            var october = await provider.GetSchedule(new Season(2019, 2019), Month.October());
            //await provider.GetSchedule(new Season(2019, 2019), Month.November());

            //foreach (var team in TeamsFactory.Teams)
            //{
            //    await provider.GetTeamData(team.Value, new Season(2019));

            //    await Task.Delay(TimeSpan.FromSeconds(2));
            //}
        }
    }
}