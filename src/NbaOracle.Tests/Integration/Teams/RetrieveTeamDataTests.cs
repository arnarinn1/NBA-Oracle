using System;
using System.Threading.Tasks;
using NbaOracle.Providers;
using NbaOracle.Providers.BasketballReference.Teams;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Integration.Teams
{
    public class RetrieveTeamDataTests : IntegrationTestBase
    {
        [Fact]
        public async Task RetrieveDataFor2019_2020Season()
        {
            await ExecuteTest(async c =>
            {
                var provider = c.GetInstance<ITeamProvider>();

                foreach (var team in TeamsFactory.Teams)
                {
                    await provider.GetTeamData(team.Value, new Season(2019));

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }
    }
}