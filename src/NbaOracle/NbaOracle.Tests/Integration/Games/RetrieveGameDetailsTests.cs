using System.Threading.Tasks;
using NbaOracle.Providers.BasketballReference.Games.Details;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Integration.Games
{
    public class RetrieveGameDetailsTests : IntegrationTestBase
    {
        [Fact]
        public async Task Provider()
        {
            await ExecuteTest(async c =>
            {
                var provider = c.GetInstance<IGameDetailsProvider>();

                var result = await provider.GetGameDetails(new Season(2019), new BoxScoreLink("/boxscores/201910220TOR.html"));
            });
        }
    }
}