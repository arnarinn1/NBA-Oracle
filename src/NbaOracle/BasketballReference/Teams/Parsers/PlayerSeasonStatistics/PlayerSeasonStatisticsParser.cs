﻿using System.Collections.Generic;
using AngleSharp.Dom;
using BuildingBlocks.DocumentLoaders.Extensions;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics.Data;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayerSeasonStatistics
{
    public class PlayerSeasonStatisticsParser : DocumentWithCommentTagBase<IEnumerable<PlayerSeasonStatisticsData>>
    {
        protected override string CommentTagSelector => "div[id='all_totals']";

        protected override IEnumerable<PlayerSeasonStatisticsData> ApplyInnerDocument(IDocument document)
        {
            var players = document.QuerySelectorAll("tbody tr");

            var output = new List<PlayerSeasonStatisticsData>();

            foreach (var player in players)
            {
                var playerName = player.GetTextContent("td[data-stat='player']");

                var gamesPlayed = player.GetTextContent("td[data-stat='gs']");
                var minutesPlayed = player.GetTextContent("td[data-stat='mp']");

                var fieldGoalsMade = player.GetTextContent("td[data-stat='fg']");
                var fieldGoalsAttempted = player.GetTextContent("td[data-stat='fga']");

                var threePointersMade = player.GetTextContent("td[data-stat='fg3']");
                var threePointersAttempted = player.GetTextContent("td[data-stat='fg3a']");

                var twoPointersMade = player.GetTextContent("td[data-stat='fg2']");
                var twoPointersAttempted = player.GetTextContent("td[data-stat='fg2a']");

                var effectiveFieldGoalPercentage = player.GetTextContent("td[data-stat='efg_pct']");

                var freeThrowsMade = player.GetTextContent("td[data-stat='ft']");
                var freeThrowsAttempted = player.GetTextContent("td[data-stat='fta']");

                var offensiveRebounds = player.GetTextContent("td[data-stat='orb']");
                var defensiveRebounds = player.GetTextContent("td[data-stat='drb']");

                var assists = player.GetTextContent("td[data-stat='ast']");
                var steals = player.GetTextContent("td[data-stat='stl']");
                var blocks = player.GetTextContent("td[data-stat='blk']");
                var turnovers = player.GetTextContent("td[data-stat='tov']");
                var personalFouls = player.GetTextContent("td[data-stat='pf']");

                var points = player.GetTextContent("td[data-stat='pts']");

                output.Add(new PlayerSeasonStatisticsData(playerName, gamesPlayed, minutesPlayed, fieldGoalsMade, fieldGoalsAttempted, threePointersMade, threePointersAttempted, twoPointersMade, twoPointersAttempted, effectiveFieldGoalPercentage, freeThrowsMade, freeThrowsAttempted, offensiveRebounds, defensiveRebounds, assists, steals, blocks, turnovers, personalFouls, points));
            }

            return output;
        }
    }
}