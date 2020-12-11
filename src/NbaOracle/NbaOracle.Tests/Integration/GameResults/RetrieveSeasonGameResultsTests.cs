using System.Collections.Generic;
using System.Threading.Tasks;
using NbaOracle.Providers;
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
            var season = new Season(seasonStartYear, seasonStartYear == 2019 ? 2019 : null as int?);

            await ExecuteTest(async c =>
            {
                var provider = c.GetInstance<IMonthlyGameResultsProvider>();
                var processor = c.GetInstance<ISeasonGameResultsProcessor>();

                var seasonGameResults = new List<GameData>();

                foreach (var month in SeasonFactory.GetMonthsInSeason(season))
                {
                    if (season == new Season(2019) && month == Month.January()) //todo - fubbgly fix this
                        season = new Season(2019, 2020); 

                    var monthGameResults = await provider.GetSchedule(season, month);

                    //gameResults.AddRange();

                    //await Task.Delay(TimeSpan.FromSeconds(2));
                }

            });
        }
    }
}