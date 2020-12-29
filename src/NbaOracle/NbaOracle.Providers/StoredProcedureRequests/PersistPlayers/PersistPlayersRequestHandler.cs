using System;
using System.Data;
using BuildingBlocks.StoredProcedureHandlers.Implementations;
using Dapper;

namespace NbaOracle.Providers.StoredProcedureRequests.PersistPlayers
{
    public class PersistPlayersRequestHandler : DapperStoredProcedureHandler<PersistPlayersRequest, bool>
    {
        public PersistPlayersRequestHandler(IDbConnection dbConnection) : base(dbConnection) { }

        protected override string ProcedureName => "nba.sp_MergePlayers";

        protected override bool CreateResult(PersistPlayersRequest request, DynamicParameters parameters) => true;

        protected override void AddParameters(PersistPlayersRequest request, DynamicParameters parameters)
        {
            var dt = new DataTable();
            dt.Columns.Add("Identifier", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("BirthDate", typeof(DateTime));
            dt.Columns.Add("BirthCountry", typeof(string));
            dt.Columns.Add("College", typeof(string));

            foreach (var player in request.Players)
            {
                dt.Rows.Add(player.Identifier, player.Name, player.BirthDate, player.BirthCountry, player.College);
            }

            parameters.Add("@Players", dt.AsTableValuedParameter("nba.tt_MergePlayerDataType"));
        }
    }
}