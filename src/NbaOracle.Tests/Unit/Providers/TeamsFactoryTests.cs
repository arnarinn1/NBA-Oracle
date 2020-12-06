using System;
using FluentAssertions;
using NbaOracle.Providers;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers
{
    public class TeamsFactoryTests
    {
        [Fact]
        public void ThereShouldBe30Teams()
        {
            TeamsFactory.Teams.Count.Should().Be(30);
        }
        
        [Theory]
        [InlineData("ATL")]
        [InlineData("BOS")]
        [InlineData("NJN")]
        [InlineData("CHO")]
        [InlineData("CHI")]
        [InlineData("CLE")]
        [InlineData("DAL")]
        [InlineData("DEN")]
        [InlineData("DET")]
        [InlineData("GSW")]
        [InlineData("HOU")]
        [InlineData("IND")]
        [InlineData("LAC")]
        [InlineData("LAL")]
        [InlineData("MEM")]
        [InlineData("MIA")]
        [InlineData("MIL")]
        [InlineData("MIN")]
        [InlineData("NOP")]
        [InlineData("NYK")]
        [InlineData("OKC")]
        [InlineData("ORL")]
        [InlineData("PHI")]
        [InlineData("PHO")]
        [InlineData("POR")]
        [InlineData("SAC")]
        [InlineData("SAS")]
        [InlineData("TOR")]
        [InlineData("UTA")]
        [InlineData("WAS")]
        public void GetTeam_ShouldFindTeam_WhenNameIdentifierIsKnown(string nameIdentifier)
        {
            var team = TeamsFactory.GetTeam(nameIdentifier);
            team.Should().NotBeNull();
            team.NameIdentifier.Should().BeEquivalentTo(nameIdentifier);
        }

        [Fact]
        public void GetTeam_ShouldThrowException_WhenNameIdentifierIsUnknown()
        {
            Action action = () => TeamsFactory.GetTeam("BLA");
            action.Should().Throw<ArgumentException>().Which.Message.Should().Be("Team with NameIdentifier = 'BLA' not found");
        }
    }
}