using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers.Parsers.PlayerSeasonStatistics
{
    public class PlayerSeasonStatisticsParserTests : UnitBase
    {
        private const string EmbeddedResourceLocation = "NbaOracle.Tests.Unit.Providers.Parsers.PlayerSeasonStatistics.player_statistics_example_html_data.txt";

        [Fact]
        public async Task Parse_ShouldParseHtml_WhenStatisticsIsPresent()
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var parser = new PlayerSeasonStatisticsParser();

            var content = await ReadEmbeddedResource(EmbeddedResourceLocation);
            var document = await context.OpenAsync(request => request.Content(content));

            var output = parser.Parse(document);

            output.Count().Should().Be(20);
        }
    }
}