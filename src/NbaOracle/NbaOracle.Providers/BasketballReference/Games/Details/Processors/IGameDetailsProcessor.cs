using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Details.Processors
{
    public interface IGameDetailsProcessor
    {
        Task Process(Season season, GameDetailsData gameDetails);
    }
}