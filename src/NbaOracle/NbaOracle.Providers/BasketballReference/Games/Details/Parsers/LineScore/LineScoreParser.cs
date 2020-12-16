using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using BuildingBlocks.DocumentLoaders.Extensions;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore.Data;
using ValueObjects;
using ValueObjects.Extensions;

namespace NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore
{
    public class LineScoreParser : DocumentWithCommentTagBase<LineScoreData>
    {
        protected override string CommentTagSelector => "div[id='all_line_score']";

        protected override LineScoreData ApplyInnerDocument(IDocument document)
        {
            var element = document.QuerySelectorAll("div[id='div_line_score'] tbody tr");

            if (element.Length != 2)
                return null;

            var visitorTeam = element[0];
            var homeTeam = element[1];

            var visitorTeamName = visitorTeam.GetTextContent("th[data-stat='team']");
            var homeTeamName = homeTeam.GetTextContent("th[data-stat='team']");

            var visitor1QuarterScore = visitorTeam.GetTextContentAsInt("td[data-stat='1']");
            var visitor2QuarterScore = visitorTeam.GetTextContentAsInt("td[data-stat='2']");
            var visitor3QuarterScore = visitorTeam.GetTextContentAsInt("td[data-stat='3']");
            var visitor4QuarterScore = visitorTeam.GetTextContentAsInt("td[data-stat='4']");
            var visitorOvertimeScores = GetOvertimeScores(visitorTeam);

            var home1QuarterScore = homeTeam.GetTextContentAsInt("td[data-stat='1']");
            var home2QuarterScore = homeTeam.GetTextContentAsInt("td[data-stat='2']");
            var home3QuarterScore = homeTeam.GetTextContentAsInt("td[data-stat='3']");
            var home4QuarterScore = homeTeam.GetTextContentAsInt("td[data-stat='4']");
            var homeOvertimeScores = GetOvertimeScores(homeTeam);

            return new LineScoreData(homeTeamName, visitorTeamName, home1QuarterScore, home2QuarterScore, home3QuarterScore, home4QuarterScore, homeOvertimeScores, visitor1QuarterScore, visitor2QuarterScore, visitor3QuarterScore, visitor4QuarterScore, visitorOvertimeScores);
        }

        private static IEnumerable<OvertimeScoreData> GetOvertimeScores(IParentNode element)
        {
            var overtimeScores = new List<OvertimeScoreData>();
            
            foreach (var overtimeElement in element.Children.Where(x => x.GetAttribute("data-stat").EndsWith("OT")))
            {
                var overtime = new Overtime(overtimeElement.GetAttribute("data-stat"));
                var score = ParsingMethods.ToInt(overtimeElement.TextContent);
                
                overtimeScores.Add(new OvertimeScoreData(overtime.Count, score));
            }

            return overtimeScores;
        }
    }
}