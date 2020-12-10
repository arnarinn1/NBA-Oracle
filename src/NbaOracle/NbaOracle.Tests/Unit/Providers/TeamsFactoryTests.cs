using FluentAssertions;
using NbaOracle.Providers;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Unit.Providers
{
    public class TeamsFactoryTests
    {
        [Fact]
        public void ThereShouldBe30Teams()
        {
            var seasons = new int[] { 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019 };
            
            foreach (var season in seasons)
                TeamsFactory.GetTeamsBySeason(new Season(season)).Count.Should().Be(30);
        }
    }
}