using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers.Teams.Parsers.PlayByPlay
{
    public class PlayByPlayParserTests : UnitBase
    {
        private const string EmbeddedResourceLocation = "NbaOracle.Tests.Unit.Providers.Teams.Parsers.PlayByPlay.play_by_play_example_html_data.txt"; //fix this 

        [Fact]
        public async Task Parse_ShouldParseHtml_WhenPlayByPlayIsPresent()
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var parser = new PlayByPlayParser();

            var content = await ReadEmbeddedResource(EmbeddedResourceLocation);
            var document = await context.OpenAsync(request => request.Content(content));

            var output = parser.Parse(document);

            output.Count().Should().Be(20);
        }
    }
}