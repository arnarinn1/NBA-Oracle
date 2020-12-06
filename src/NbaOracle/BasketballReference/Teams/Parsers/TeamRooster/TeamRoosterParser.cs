﻿using AngleSharp.Dom;
using BuildingBlocks.DocumentLoaders.Extensions;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster
{
    public class TeamRoosterParser : IDocumentParser<TeamRoosterData>
    {
        public TeamRoosterData Parse(IDocument document)
        {
            var output = new TeamRoosterData();

            foreach (var player in document.QuerySelectorAll("div[id='all_roster'] tbody tr"))
            {
                var playerName = player.GetTextContent("td[data-stat='player']");
                var playerNumber = player.GetTextContent("th[data-stat='number']");
                var position = player.GetTextContent("td[data-stat='pos']");
                var birthDate = player.GetAttributeFromElement("td[data-stat='birth_date']", "csk");
                var birthCountry = player.GetTextContent("td[data-stat='birth_country']");
                var height = player.GetTextContent("td[data-stat='height']");
                var weight = player.GetTextContent("td[data-stat='weight']");
                var yearsExperience = player.GetTextContent("td[data-stat='years_experience']");
                var college = player.GetTextContent("td[data-stat='college']");

                output.AddPlayer(new PlayerRoosterData(playerName, playerNumber, position, birthDate, birthCountry, height, weight, yearsExperience, college));
            }

            return output;
        }
    }
}