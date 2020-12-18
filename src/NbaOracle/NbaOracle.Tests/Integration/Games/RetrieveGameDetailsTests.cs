using System.Threading.Tasks;
using NbaOracle.Providers.BasketballReference.Games.Details;
using NbaOracle.Providers.BasketballReference.Games.Details.Processors;
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
                var processor = c.GetInstance<IGameDetailsProcessor>();

                var result = await provider.GetGameDetails(new Season(2019), new BoxScoreLink("/boxscores/201910220TOR.html"));

                await processor.Process(new Season(2019), result);
            });
        }
    }
}