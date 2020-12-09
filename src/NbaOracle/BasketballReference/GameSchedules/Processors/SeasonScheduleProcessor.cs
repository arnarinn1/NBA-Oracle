using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameSchedules.Processors
{
    public class SeasonScheduleProcessor : ISeasonScheduleProcessor
    {
        public Task Process(Season season)
        {
            return Task.CompletedTask;
        }
    }
}