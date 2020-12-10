using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameSchedules.Processors
{
    public interface ISeasonScheduleProcessor
    {
        Task Process(Season season);
    }
}