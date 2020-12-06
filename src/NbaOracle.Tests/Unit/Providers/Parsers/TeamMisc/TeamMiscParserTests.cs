using System.Threading.Tasks;
using AngleSharp;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers.Parsers.TeamMisc
{
    public class TeamMiscParserTests : UnitBase
    {
        private const string EmbeddedResourceLocation = "NbaOracle.Tests.Unit.Providers.Parsers.TeamMisc.team_misc_example_html_data.txt";

        [Fact]
        public async Task Parse_ShouldParseHtml_WhenRoosterIsPresent()
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var parser = new TeamMiscParser();

            var content = await ReadEmbeddedResource(EmbeddedResourceLocation);
            var document = await context.OpenAsync(request => request.Content(content));

            var output = parser.Parse(document);

            output.WinsLeagueRank.Should().Be("3");
        }
    }
}