using System.Threading.Tasks;
using AngleSharp;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster;
using Xunit;

namespace NbaOracle.Tests.Unit.Parsers
{
    public class TeamRoosterParserTests
    {
        [Fact]
        public async Task Foo()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var parser = new TeamRoosterParser();

            //var document = context.OpenAsync(request => request.Content())

            //parser.Parse();
        }
    }
}