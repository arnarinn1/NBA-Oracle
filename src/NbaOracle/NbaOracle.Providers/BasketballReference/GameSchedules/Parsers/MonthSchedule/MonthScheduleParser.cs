using AngleSharp.Dom;
using BuildingBlocks.DocumentLoaders.Extensions;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.MonthSchedule.Data;

namespace NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.MonthSchedule
{
    public class MonthScheduleParser : IDocumentParser<MonthScheduleData>
    {
        public MonthScheduleData Parse(IDocument document)
        {
            var output = new MonthScheduleData();

            var games = document.QuerySelectorAll("div[id='all_schedule'] tbody tr");

            foreach (var game in games)
            {
                var gameDate = game.GetAttributeFromElementAndRemoveLastCharactersAsDate("th[data-stat='date_game']", "csk", 4);

                var visitorTeam = game.GetAttributeFromElementAndTakeLeadingCharacters("td[data-stat='visitor_team_name']", "csk", 3);
                var homeTeam = game.GetAttributeFromElementAndTakeLeadingCharacters("td[data-stat='home_team_name']", "csk", 3);

                var visitorPoints = game.GetTextContentAsInt("td[data-stat='visitor_pts']");
                var homePoints = game.GetTextContentAsInt("td[data-stat='home_pts']");

                var boxScoreLink = game.GetAttributeFromElement("td[data-stat='box_score_text'] a", "href");

                var overtimes = game.GetTextContent("td[data-stat='overtimes']");
                var attendance = game.GetTextContentAsIntAndRemoveSpecialCharacters("td[data-stat='attendance']");

                output.AddGameResult(new GameResult(gameDate, visitorTeam, homeTeam, visitorPoints, homePoints, boxScoreLink, overtimes, attendance));
            }

            return output;
        }
    }
}