using System.Linq;
using AngleSharp.Dom;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster;
using NbaOracle.Tests.Unit.Fixtures;
using Xunit;
// ReSharper disable PossibleMultipleEnumeration

namespace NbaOracle.Tests.Unit.Providers.Teams.Parsers.TeamRooster
{
    public class TeamRoosterParserTests : IClassFixture<DocumentFixture>
    {
        private readonly IDocument _document;
        private readonly TeamRoosterParser _parser;

        public TeamRoosterParserTests(DocumentFixture fixture)
        {
            _document = fixture.CreateDocument("NbaOracle.Tests.Unit.Providers.Teams.Parsers.TeamRooster.team_rooster_example_html_data.txt").GetAwaiter().GetResult();
            _parser = new TeamRoosterParser();
        }

        [Fact]
        public void Parse_ShouldParse_WhenDocumentIsValid()
        {
            var output = _parser.Parse(_document);
            var player = output.Single(x => x.Name == "LeBron James");
            
            output.Count().Should().Be(20);

            player.Height.Should().Be(205.74);
            player.Position.Should().Be("PG");
            player.JerseyNumber.Should().Be("23");
            player.NumberOfYearInLeague.Should().Be(17);
            player.Weight.Should().Be(113.4);
        }
    }
}