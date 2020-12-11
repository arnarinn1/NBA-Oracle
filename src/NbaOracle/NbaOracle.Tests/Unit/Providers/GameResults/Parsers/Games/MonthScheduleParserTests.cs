using System.Linq;
using AngleSharp.Dom;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.GameResults.Parsers.Games;
using NbaOracle.Tests.Unit.Fixtures;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers.GameResults.Parsers.Games
{
    public class MonthScheduleParserTests : IClassFixture<DocumentFixture>
    {
        private readonly IDocument _document;
        private readonly GamesParser _parser;

        public MonthScheduleParserTests(DocumentFixture fixture)
        {
            _document = fixture.CreateDocument("NbaOracle.Tests.Unit.Providers.GameResults.Parsers.Games.month_schedule_example_html_data.txt").GetAwaiter().GetResult();
            _parser = new GamesParser();
        }

        [Fact]
        public void Parse_ShouldParse_WhenDocumentIsValid()
        {
            var output = _parser.Parse(_document);
            output.Count().Should().Be(2);
        }
    }
}