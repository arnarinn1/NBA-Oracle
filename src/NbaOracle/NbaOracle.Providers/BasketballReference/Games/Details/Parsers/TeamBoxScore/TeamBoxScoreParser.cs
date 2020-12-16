using System.Linq;
using AngleSharp.Dom;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.TeamBoxScore.Data;

namespace NbaOracle.Providers.BasketballReference.Games.Details.Parsers.TeamBoxScore
{
    public class TeamBoxScoreParser : IDocumentParser<TeamBoxScoreData, string>
    {
        public TeamBoxScoreData Parse(IDocument document, string team)
        {
            var element = document.QuerySelector($"div#all_box-{team}-game-basic div#all_box-{team}-game-basic");

            var players = element.QuerySelectorAll("tbody tr:not(.thead)");

            return null;
        }
    }
}