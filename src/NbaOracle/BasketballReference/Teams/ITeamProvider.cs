using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams
{
    public interface ITeamProvider
    {
        Task<TeamData> GetTeamData(Team team, SeasonIdentifier season);
    }
}