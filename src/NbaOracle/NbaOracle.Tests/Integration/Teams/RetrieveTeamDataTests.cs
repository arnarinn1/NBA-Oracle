using System;
using System.Threading.Tasks;
using NbaOracle.Providers;
using NbaOracle.Providers.BasketballReference.Teams;
using NbaOracle.Providers.BasketballReference.Teams.Processors;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Integration.Teams
{
    public class RetrieveTeamDataTests : IntegrationTestBase
    {
        [Theory]
        [InlineData(2019)]
        [InlineData(2018)]
        [InlineData(2017)]
        [InlineData(2016)]
        [InlineData(2015)]
        [InlineData(2014)]
        [InlineData(2013)]
        [InlineData(2012)]
        [InlineData(2011)]
        [InlineData(2010)]
        public async Task ProcessData(int seasonStartYear)
        {
            var season = new Season(seasonStartYear);

            await ExecuteTest(async c =>
            {
                var provider = c.GetInstance<ITeamProvider>();
                var processor = c.GetInstance<ITeamProcessor>();

                foreach (var team in TeamsFactory.GetTeamsBySeason(season))
                {
                    var teamData = await provider.GetTeamData(team, season);

                    await processor.Process(team, season, teamData);

                    await Task.Delay(TimeSpan.FromSeconds(3));
                }
            });
        }
    }
}