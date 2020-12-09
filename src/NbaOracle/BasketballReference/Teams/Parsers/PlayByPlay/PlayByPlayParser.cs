using System.Collections.Generic;
using AngleSharp.Dom;
using BuildingBlocks.DocumentLoaders.Extensions;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay.Data;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.PlayByPlay
{
    public class PlayByPlayParser : DocumentWithCommentTagBase<IEnumerable<PlayByPlayData>>
    {
        protected override string CommentTagSelector => "div[id='all_pbp']";

        protected override IEnumerable<PlayByPlayData> ApplyInnerDocument(IDocument document)
        {
            var players = document.QuerySelectorAll("tbody tr");

            var output = new List<PlayByPlayData>();

            foreach (var player in players)
            {
                var playerName = player.GetTextContent("td[data-stat='player']");
                var games = player.GetTextContentAsInt("td[data-stat='g']");
                var minutesPlayed = player.GetTextContentAsInt("td[data-stat='mp']");
                var plusMinusOnCourt = player.GetTextContent("td[data-stat='plus_minus_on']");
                var plusMinusNetOnCourt = player.GetTextContent("td[data-stat='plus_minus_net']");

                output.Add(new PlayByPlayData(playerName, games, minutesPlayed,plusMinusOnCourt, plusMinusNetOnCourt));
            }

            return output;
        }
    }
}