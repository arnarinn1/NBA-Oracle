using System;
using System.Threading.Tasks;
using BuildingBlocks.StoredProcedureHandlers;
using NbaOracle.Providers.StoredProcedureRequests.PersistPlayers;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Teams.Processors
{
    public class PersistTeamDataToDatabaseProcessor : ITeamProcessor
    {
        private readonly IStoredProcedureHandler<PersistPlayersRequest, bool> _handler;

        public PersistTeamDataToDatabaseProcessor(IStoredProcedureHandler<PersistPlayersRequest, bool> handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public async Task Process(Team team, Season season, TeamData teamData)
        {
            await _handler.Execute(PersistPlayersRequestFactory.CreateFromPlayerRooster(teamData.Rooster));
        }
    }
}