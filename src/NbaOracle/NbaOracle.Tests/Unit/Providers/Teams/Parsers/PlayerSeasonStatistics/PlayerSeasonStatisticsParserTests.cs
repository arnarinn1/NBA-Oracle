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

            player.FieldGoalsMade.Should().Be(643);
            player.FieldGoalsAttempted.Should().Be(1303);
            player.FieldGoalPercentage.Should().Be(.493);

            player.ThreePointersMade.Should().Be(148);
            player.ThreePointersAttempted.Should().Be(425);
            player.ThreePointersPercentage.Should().Be(.348);

            player.TwoPointersMade.Should().Be(495);
            player.TwoPointersAttempted.Should().Be(878);
            player.TwoPointersPercentage.Should().Be(.564);

            player.FreeThrowsMade.Should().Be(264);
            player.FreeThrowsAttempted.Should().Be(381);
            player.FreeThrowsPercentage.Should().Be(.693);

            player.EffectiveFieldGoalPercentage.Should().Be(.550);

            player.OffensiveRebounds.Should().Be(66);
            player.DefensiveRebounds.Should().Be(459);
            player.TotalRebounds.Should().Be(525);
            player.ReboundsPerGame.Should().Be(7.8);

            player.Assists.Should().Be(684);
            player.AssistsPerGame.Should().Be(10.2);

            player.Steals.Should().Be(78);
            player.StealsPerGame.Should().Be(1.2);

            player.Blocks.Should().Be(36);
            player.BlocksPerGame.Should().Be(0.5);

            player.Turnovers.Should().Be(261);
            player.TurnoversPerGame.Should().Be(3.9);

            player.PersonalFouls.Should().Be(118);
            player.PersonalFoulsPerGame.Should().Be(1.8);

            player.Points.Should().Be(1698);
            player.PointsPerGame.Should().Be(25.3);
        }
    }
}