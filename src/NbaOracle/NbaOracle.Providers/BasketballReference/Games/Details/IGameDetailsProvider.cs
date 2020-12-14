using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details
{
    public interface IGameDetailsProvider
    {
        Task<GameDetailsData> GetGameDetails(Season season, BoxScoreLink boxScoreLink);
    }
}