using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameResults
{
    public interface IMonthlyGameResultsProvider
    {
        Task<MonthlyGameResultsData> GetSchedule(Season season, Month month);
    }
}