using AngleSharp.Dom;
using BuildingBlocks.DocumentLoaders.Extensions;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc.Data;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamMisc
{
    public class TeamMiscParser : DocumentWithCommentTagBase<TeamMiscData>
    {
        protected override string CommentTagSelector => "div[id='all_team_misc']";
        
        protected override TeamMiscData ApplyInnerDocument(IDocument document)
        {
            var element = document.QuerySelectorAll("tbody tr");

            if (element.Length != 2)
                return null;

            var teamStats = element[0];
            var teamLeagueRanking = element[1];

            var wins = teamStats.GetTextContentAsInt("td[data-stat='wins']");
            var winsRank = teamLeagueRanking.GetTextContentAsInt("td[data-stat='wins']");

            var losses = teamStats.GetTextContentAsInt("td[data-stat='losses']");
            var lossesRank = teamLeagueRanking.GetTextContentAsInt("td[data-stat='losses']");

            var marginOfVictory = teamStats.GetTextContentAsDouble("td[data-stat='mov']");
            var marginOfVictoryRank = teamLeagueRanking.GetTextContentAsInt("td[data-stat='mov']");

            return new TeamMiscData(wins, winsRank, losses, lossesRank, marginOfVictory, marginOfVictoryRank);
        }
    }
}