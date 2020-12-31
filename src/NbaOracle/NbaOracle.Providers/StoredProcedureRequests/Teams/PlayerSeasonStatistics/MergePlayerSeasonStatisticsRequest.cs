using System.Collections.Generic;
using BuildingBlocks.StoredProcedureHandlers;

namespace NbaOracle.Providers.StoredProcedureRequests.Teams.PlayerSeasonStatistics
{
    public class MergePlayerSeasonStatisticsRequest : IStoredProcedureRequest
    {
        public MergePlayerSeasonStatisticsRequest(IEnumerable<PlayerSeasonStatisticsSeasonRequestData> playerStatistics)
        {
            PlayerStatistics = playerStatistics;
        }

        public IEnumerable<PlayerSeasonStatisticsSeasonRequestData> PlayerStatistics { get; }
    }
}