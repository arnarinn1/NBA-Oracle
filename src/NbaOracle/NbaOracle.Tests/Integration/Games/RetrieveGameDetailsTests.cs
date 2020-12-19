using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NbaOracle.Providers.BasketballReference.Games.Details;
using NbaOracle.Providers.BasketballReference.Games.Details.Processors;
using NbaOracle.Providers.BasketballReference.Games.Results;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Integration.Games
{
    public class RetrieveGameDetailsTests : IntegrationTestBase
    {
        [Theory]
        [InlineData(2019)]
        public async Task Provider(int seasonStartYear)
        {
            var season = new Season(seasonStartYear);
            
            var boxScoreLinks = new List<BoxScoreLink>();

            await ExecuteTest(async c =>
            {
                var provider = c.GetInstance<IMonthlyGameResultsProvider>();

                foreach (var month in season.GetMonthsInSeason())
                {
                    var games = await provider.GetSchedule(season, month);
                    boxScoreLinks.AddRange(games.GameResults.Select(x => new BoxScoreLink(x.BoxScoreLink)));
                }
            });

            await ExecuteTest(async c =>
            {
                var provider = c.GetInstance<IGameDetailsProvider>();
                var processor = c.GetInstance<IGameDetailsProcessor>();

                foreach (var boxScoreLink in boxScoreLinks.Where(x => x.GameDate >= new DateTime(2019, 12, 06)))
                {
                    var result = await provider.GetGameDetails(season, boxScoreLink);

                    await processor.Process(season, result);

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }
    }
}