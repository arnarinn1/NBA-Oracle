using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameSchedules
{
    public interface IMonthlyGameSchedulesProvider
    {
        Task GetSchedule(Season season, Month month);
    }
}