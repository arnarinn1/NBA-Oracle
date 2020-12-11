using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NbaOracle.Providers.BasketballReference.GameResults;
using NbaOracle.Providers.BasketballReference.GameResults.Parsers.Games.Data;
using NbaOracle.Providers.BasketballReference.GameResults.Processors;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Integration.GameResults
{
    public class RetrieveSeasonGameResultsTests : IntegrationTestBase
    {
        [Theory]
        [InlineData(2019)]
        public async Task ProcessData(int seasonStartYear)
        {
            var season = new Season(seasonStartYear);

            await ExecuteTest(async c =>
            {
                var provider = c.GetInstance<IMonthlyGameResultsProvider>();
                var processor = c.GetInstance<ISeasonGameResultsProcessor>();

                var seasonGameResults = new List<GameData>();

                foreach (var month in season.GetMonthsInSeason())
                {
                    var monthGameResults = await provider.GetSchedule(season, month);

                    seasonGameResults.AddRange(monthGameResults.GameResults);

                    //await Task.Delay(TimeSpan.FromSeconds(2));
                }

                await processor.Process(season, seasonGameResults);
            });
        }
    }
}