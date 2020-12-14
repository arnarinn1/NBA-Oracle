using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Results
{
    public interface IMonthlyGameResultsProvider
    {
        Task<MonthlyGameResultsData> GetSchedule(Season season, Month month);
    }
}