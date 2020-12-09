using System.Linq;
using AngleSharp.Dom;
using FluentAssertions;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics;
using NbaOracle.Tests.Unit.Fixtures;
using Xunit;
// ReSharper disable PossibleMultipleEnumeration

namespace NbaOracle.Tests.Unit.Providers.Teams.Parsers.PlayerSeasonStatistics
{
    public class PlayerSeasonStatisticsParserTests : IClassFixture<DocumentFixture>
    {
        private readonly IDocument _document;
        private readonly PlayerSeasonStatisticsParser _parser;

        public PlayerSeasonStatisticsParserTests(DocumentFixture fixture)
        {
            _document = fixture.CreateDocument("NbaOracle.Tests.Unit.Providers.Teams.Parsers.PlayerSeasonStatistics.player_statistics_example_html_data.txt").GetAwaiter().GetResult();
            _parser = new PlayerSeasonStatisticsParser();
        }

        [Fact]
        public void Parse_ShouldParse_WhenDocumentIsValid()
        {
            var output = _parser.Parse(_document);

            var player = output.Single(x => x.PlayerName == "LeBron James");

            output.Count().Should().Be(20);

            player.GamesPlayed.Should().Be(67);
            player.MinutesPlayed.Should().Be(2316);
            player.MinutesPlayedPerGame.Should().Be(34.6);
        }
    }
}