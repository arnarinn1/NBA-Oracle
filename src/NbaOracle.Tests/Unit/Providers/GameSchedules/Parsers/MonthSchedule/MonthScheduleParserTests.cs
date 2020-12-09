using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.MonthSchedule;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers.GameSchedules.Parsers.MonthSchedule
{
    public class MonthScheduleParserTests : UnitBase
    {
        private const string EmbeddedResourceLocation = "NbaOracle.Tests.Unit.Providers.GameSchedules.Parsers.MonthSchedule.month_schedule_example_html_data.txt";

        [Fact]
        public async Task Parse_ShouldParseHtml_WhenHtmlIsValid()
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var parser = new MonthScheduleParser();

            var content = await ReadEmbeddedResource(EmbeddedResourceLocation);
            var document = await context.OpenAsync(request => request.Content(content));

            var output = parser.Parse(document);

            output.GameResults.Count().Should().Be(2);
        }
    }
}