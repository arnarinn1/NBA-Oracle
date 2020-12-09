using System.Linq;
using AngleSharp.Dom;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay;
using NbaOracle.Tests.Unit.Fixtures;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers.Teams.Parsers.PlayByPlay
{
    public class PlayByPlayParserTests : UnitBase, IClassFixture<DocumentFixture>
    {
        private readonly IDocument _document;
        private readonly PlayByPlayParser _parser;

        public PlayByPlayParserTests(DocumentFixture fixture)
        {
            _document = fixture.CreateDocument("NbaOracle.Tests.Unit.Providers.Teams.Parsers.PlayByPlay.play_by_play_example_html_data.txt").GetAwaiter().GetResult();
            _parser = new PlayByPlayParser();
        }

        [Fact]
        public void Parse_ShouldParse_WhenDocumentIsValid()
        {
            var output = _parser.Parse(_document).ToArray();

            var player = output.Single(x => x.PlayerName == "LeBron James");

            output.Count().Should().Be(20);
            player.Games.Should().Be(67);
            player.MinutesPlayed.Should().Be(2316);
            player.PlusMinusOnCourt.Should().Be(9.0);
            player.PlusMinusNetOnOffCourt.Should().Be(9.9);
        }
    }
}