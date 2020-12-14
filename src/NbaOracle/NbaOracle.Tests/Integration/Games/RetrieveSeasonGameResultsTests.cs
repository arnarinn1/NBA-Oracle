using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NbaOracle.Providers.BasketballReference.Games.Results;
using NbaOracle.Providers.BasketballReference.Games.Results.Parsers.Games.Data;
using NbaOracle.Providers.BasketballReference.Games.Results.Processors;
using ValueObjects;
using Xunit;

namespace NbaOracle.Tests.Integration.Games
{
    public class RetrieveSeasonGameResultsTests : IntegrationTestBase
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
                var provider = c.GetInstance<IMonthlyGameResultsProvider>();
                var processor = c.GetInstance<ISeasonGameResultsProcessor>();

                var seasonGameResults = new List<GameData>();

                foreach (var month in season.GetMonthsInSeason())
                {
                    var monthGameResults = await provider.GetSchedule(season, month);

                    seasonGameResults.AddRange(monthGameResults.GameResults);

                    await Task.Delay(TimeSpan.FromSeconds(2));
                }

                await processor.Process(season, seasonGameResults);
            });
        }
    }
}