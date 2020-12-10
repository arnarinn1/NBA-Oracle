using System.Threading.Tasks;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams.Processors
{
    public interface ITeamProcessor
    {
        Task Process(Team team, Season season, TeamData teamData);
    }
}