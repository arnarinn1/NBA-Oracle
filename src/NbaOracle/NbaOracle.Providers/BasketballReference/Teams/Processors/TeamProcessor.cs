using System.Threading.Tasks;

namespace NbaOracle.Providers.BasketballReference.Teams.Processors
{
    public class TeamProcessor : ITeamProcessor
    {
        public Task Process(TeamData teamData)
        {
            return Task.CompletedTask;
        }
    }
}