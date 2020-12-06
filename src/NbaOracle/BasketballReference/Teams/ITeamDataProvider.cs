using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public interface ITeamDataProvider
    {
        Task GetTeamData(Team team, SeasonIdentifier season);
    }
}