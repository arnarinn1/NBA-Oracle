using System.Threading.Tasks;

namespace NbaOracle.Providers.BasketballReference.Teams.Processors
{
    public interface ITeamProcessor
    {
        Task Process(TeamData teamData);
    }
}