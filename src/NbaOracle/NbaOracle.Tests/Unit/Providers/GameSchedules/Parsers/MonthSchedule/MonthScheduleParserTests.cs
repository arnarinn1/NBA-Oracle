using System.Linq;
using AngleSharp.Dom;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.MonthSchedule;
using NbaOracle.Tests.Unit.Fixtures;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers.GameSchedules.Parsers.MonthSchedule
{
    public class MonthScheduleParserTests : IClassFixture<DocumentFixture>
    {
        private readonly IDocument _document;
        private readonly MonthScheduleParser _parser;

        public MonthScheduleParserTests(DocumentFixture fixture)
        {
            _document = fixture.CreateDocument("NbaOracle.Tests.Unit.Providers.GameSchedules.Parsers.MonthSchedule.month_schedule_example_html_data.txt").GetAwaiter().GetResult();
            _parser = new MonthScheduleParser();
        }

        [Fact]
        public void Parse_ShouldParse_WhenDocumentIsValid()
        {
            var output = _parser.Parse(_document);
            output.GameResults.Count().Should().Be(2);
        }
    }
}