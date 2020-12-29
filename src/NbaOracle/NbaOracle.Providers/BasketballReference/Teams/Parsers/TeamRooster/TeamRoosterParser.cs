using System.Collections.Generic;
using AngleSharp.Dom;
using BuildingBlocks.DocumentLoaders.Extensions;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster.Data;

namespace NbaOracle.Providers.BasketballReference.Teams.Parsers.TeamRooster
{
    public class TeamRoosterParser : IDocumentParser<IEnumerable<PlayerRoosterData>>
    {
        public IEnumerable<PlayerRoosterData> Parse(IDocument document)
        {
            var output = new List<PlayerRoosterData>();

            foreach (var player in document.QuerySelectorAll("div[id='all_roster'] tbody tr"))
            {
                var playerName = player.GetTextContent("td[data-stat='player']");
                var playerNumber = player.GetTextContent("th[data-stat='number']");
                var position = player.GetTextContent("td[data-stat='pos']");
                var birthDate = player.GetAttributeFromElementAsDate("td[data-stat='birth_date']", "csk");
                var birthCountry = player.GetTextContent("td[data-stat='birth_country']");
                var height = player.GetTextContent("td[data-stat='height']");
                var weight = player.GetTextContent("td[data-stat='weight']");
                var yearsExperience = player.GetTextContent("td[data-stat='years_experience']");
                var college = player.GetTextContent("td[data-stat='college']");

                output.Add(PlayerRoosterData.Create(playerName, playerNumber, position, birthDate, birthCountry, height, weight, yearsExperience, college));
            }

            return output;
        }
    }
}