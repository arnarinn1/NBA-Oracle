using System.Linq;
using AngleSharp.Dom;
using BuildingBlocks.Parsers;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers
{
    public class TeamRoosterData
    {

    }

    public class TeamRoosterParser : IDocumentParser<TeamRoosterData>
    {
        public TeamRoosterData Parse(IDocument document)
        {
            var div = document.All.Where(x => x.LocalName == "div" && x.HasAttribute("id") && x.GetAttribute("id") == "all_roster");
            
            return new TeamRoosterData();
        }
    }
}