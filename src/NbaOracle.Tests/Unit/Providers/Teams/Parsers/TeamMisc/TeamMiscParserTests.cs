using AngleSharp.Dom;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc;
using NbaOracle.Tests.Unit.Fixtures;
using Xunit;
// ReSharper disable PossibleMultipleEnumeration

namespace NbaOracle.Tests.Unit.Providers.Teams.Parsers.TeamMisc
{
    public class TeamMiscParserTests : IClassFixture<DocumentFixture>
    {
        private readonly IDocument _document;
        private readonly TeamMiscParser _parser;

        public TeamMiscParserTests(DocumentFixture fixture)
        {
            _document = fixture.CreateDocument("NbaOracle.Tests.Unit.Providers.Teams.Parsers.TeamMisc.team_misc_example_html_data.txt").GetAwaiter().GetResult();
            _parser = new TeamMiscParser();
        }

        [Fact]
        public void Parse_ShouldParse_WhenDocumentIsValid()
        {
            var output = _parser.Parse(_document);

            output.Wins.Should().Be(52);
            output.WinsLeagueRank.Should().Be(3);
            
            output.Losses.Should().Be(19);
            output.LossesLeagueRank.Should().Be(28);

            output.MarginOfVictory.Should().Be(5.79);
            output.MarginOfVictoryLeagueRank.Should().Be(5);
        }
    }
}