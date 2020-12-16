using System;
using AngleSharp.Dom;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore;
using NbaOracle.Tests.Unit.Fixtures;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers.Games.Parsers.LineScore
{
    public class LineScoreParserTests : IClassFixture<DocumentFixture>
    {
        private readonly IDocument _document;
        private readonly LineScoreParser _parser;

        public LineScoreParserTests(DocumentFixture fixture)
        {
            _document = fixture.CreateDocument("NbaOracle.Tests.Unit.Providers.Games.Parsers.LineScore.line_score_example_html_data.txt").GetAwaiter().GetResult();
            _parser = new LineScoreParser();
        }

        [Fact]
        public void Parse_ShouldParse_WhenDocumentIsValid()
        {
            var output = _parser.Parse(_document);
            output.HomeTeam.Should().Be("TOR");
            output.VisitorTeam.Should().Be("NOP");
            output.HomeTotalScore.Should().Be(130);
            output.VisitorTotalScore.Should().Be(122);
        }
    }
}