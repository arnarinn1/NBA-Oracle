using System.Globalization;
using AngleSharp.Dom;
using BuildingBlocks.DocumentLoaders.Extensions;
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

            var output = new TeamBoxScoreData();

            var i = 0;

            foreach (var player in players)
            {
                var playerName = player.GetTextContent("th[data-stat='player']");
                var starter = i++ < 5;

                var didNotPlay = player.GetTextContent("td[data-stat='reason']")?.ToLower(CultureInfo.InvariantCulture);
                if (didNotPlay == "did not play")
                {
                    output.AddDidNotPlay(playerName);
                    continue;
                }

                var minutesPlayed = player.GetTextContent("td[data-stat='mp']");

                var fieldGoalsMade = player.GetTextContentAsInt("td[data-stat='fg']");
                var fieldGoalsAttempted = player.GetTextContentAsInt("td[data-stat='fga']");

                var threePointersMade = player.GetTextContentAsInt("td[data-stat='fg3']");
                var threePointersAttempted = player.GetTextContentAsInt("td[data-stat='fg3a']");

                var twoPointersMade = player.GetTextContentAsInt("td[data-stat='fg2']");
                var twoPointersAttempted = player.GetTextContentAsInt("td[data-stat='fg2a']");

                var freeThrowsMade = player.GetTextContentAsInt("td[data-stat='ft']");
                var freeThrowsAttempted = player.GetTextContentAsInt("td[data-stat='fta']");

                var offensiveRebounds = player.GetTextContentAsInt("td[data-stat='orb']");
                var defensiveRebounds = player.GetTextContentAsInt("td[data-stat='drb']");

                var assists = player.GetTextContentAsInt("td[data-stat='ast']");
                var steals = player.GetTextContentAsInt("td[data-stat='stl']");
                var blocks = player.GetTextContentAsInt("td[data-stat='blk']");
                var turnovers = player.GetTextContentAsInt("td[data-stat='tov']");
                var personalFouls = player.GetTextContentAsInt("td[data-stat='pf']");
                var points = player.GetTextContentAsInt("td[data-stat='pts']");

                var plusMinusScore = player.GetTextContentAsInt("td[data-stat='plus_minus']");

                output.AddPlayer(new PlayerBoxScoreData(playerName, starter, minutesPlayed, fieldGoalsMade, fieldGoalsAttempted, threePointersMade, threePointersAttempted, twoPointersMade, twoPointersAttempted, freeThrowsMade, freeThrowsAttempted, offensiveRebounds, defensiveRebounds, assists, steals, blocks, turnovers, personalFouls, points, plusMinusScore));
            }

            return output;
        }
    }
}