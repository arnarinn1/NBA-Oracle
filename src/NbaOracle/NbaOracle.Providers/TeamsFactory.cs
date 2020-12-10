using System.Collections.Generic;
using ValueObjects;

namespace NbaOracle.Providers
{
    public class TeamsFactory
    {
        public static IReadOnlyList<Team> GetTeamsBySeason(Season season)
        {
            var teams = new List<Team>
            {
                new Team("Atlanta Hawks", "ATL"),
                new Team("Boston Celtics", "BOS"),
                new Team("Chicago Bulls", "CHI"),
                new Team("Cleveland Cavaliers", "CLE"),
                new Team("Dallas Mavericks", "DAL"),
                new Team("Denver Nuggets", "DEN"),
                new Team("Detroit Pistons", "DET"),
                new Team("Golden State Warriors", "GSW"),
                new Team("Houston Rockets", "HOU"),
                new Team("Indiana Pacers", "IND"),
                new Team("Los Angeles Clippers", "LAC"),
                new Team("Los Angeles Lakers", "LAL"),
                new Team("Memphis Grizzlies", "MEM"),
                new Team("Miami Heat", "MIA"),
                new Team("Milwaukee Bucks", "MIL"),
                new Team("Minnesota Timberwolves", "MIN"),
                new Team("New York Knicks", "NYK"),
                new Team("Oklahoma City Thunder", "OKC"),
                new Team("Orlando Magic", "ORL"),
                new Team("Philadelphia 76ers", "PHI"),
                new Team("Phoenix Suns", "PHO"),
                new Team("Portland Trail Blazers", "POR"),
                new Team("Sacramento Kings", "SAC"),
                new Team("San Antonio Spurs", "SAS"),
                new Team("Toronto Raptors", "TOR"),
                new Team("Utah Jazz", "UTA"),
                new Team("Washington Wizards", "WAS"),
                season.SeasonStartYear <= 2013
                    ? new Team("Charlotte Bobcats", "CHA")
                    : new Team("Charlotte Hornets", "CHO"),
                season.SeasonStartYear <= 2012
                    ? new Team("New Orleans Hornets", "NOH")
                    : new Team("New Orleans Pelicans", "NOP"),
                season.SeasonStartYear <= 2011 
                    ? new Team("New Jersey Nets", "NJN") 
                    : new Team("Brooklyn Nets", "BRK"),
            };

            return teams;
        }
    }
}