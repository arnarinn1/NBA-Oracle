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
        //[InlineData(2019)]
        //[InlineData(2018)]
        [InlineData(2017)]
        [InlineData(2016)]
        public async Task RetrieveDataFor2019_2020Season(int seasonStartYear)
        {
            var season = new Season(seasonStartYear);

            await ExecuteTest(async c =>
            {
                var provider = c.GetInstance<ITeamProvider>();
                var processor = c.GetInstance<ITeamProcessor>();

                foreach (var (_, value) in TeamsFactory.Teams)
                {
                    var teamData = await provider.GetTeamData(value, season);

                    await processor.Process(value, season, teamData);

                    await Task.Delay(TimeSpan.FromSeconds(2));
                }
            });
        }
    }
}