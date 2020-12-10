using System;
using System.Collections.Generic;
using ValueObjects;

namespace NbaOracle.Providers
{
    public class TeamsFactory
    {
        public static Dictionary<string, Team> Teams =
            new Dictionary<string, Team>
            {
                {"ATL", new Team("Atlanta Hawks", "ATL")},
                {"BOS", new Team("Boston Celtics", "BOS")},
                {"BRK", new Team("Brooklyn Nets", "BRK")},
                {"CHI", new Team("Chicago Bulls", "CHI")},
                {"CHO", new Team("Charlotte Hornets", "CHO")},
                {"CLE", new Team("Cleveland Cavaliers", "CLE")},
                {"DAL", new Team("Dallas Mavericks", "DAL")},
                {"DEN", new Team("Denver Nuggets", "DEN")},
                {"DET", new Team("Detroit Pistons", "DET")},
                {"GSW", new Team("Golden State Warriors", "GSW")},
                {"HOU", new Team("Houston Rockets", "HOU")},
                {"IND", new Team("Indiana Pacers", "IND")},
                {"LAC", new Team("Los Angeles Clippers", "LAC")},
                {"LAL", new Team("Los Angeles Lakers", "LAL")},
                {"MEM", new Team("Memphis Grizzlies", "MEM")},
                {"MIA", new Team("Miami Heat", "MIA")},
                {"MIL", new Team("Milwaukee Bucks", "MIL")},
                {"MIN", new Team("Minnesota Timberwolves", "MIN")},
                {"NOP", new Team("New Orleans Pelicans", "NOP")},
                {"NYK", new Team("New York Knicks", "NYK")},
                {"OKC", new Team("Oklahoma City Thunder", "OKC")},
                {"ORL", new Team("Orlando Magic", "ORL")},
                {"PHI", new Team("Philadelphia 76ers", "PHI")},
                {"PHO", new Team("Phoenix Suns", "PHO")},
                {"POR", new Team("Portland Trail Blazers", "POR")},
                {"SAC", new Team("Sacramento Kings", "SAC")},
                {"SAS", new Team("San Antonio Spurs", "SAS")},
                {"TOR", new Team("Toronto Raptors", "TOR")},
                {"UTA", new Team("Utah Jazz", "UTA")},
                {"WAS", new Team("Washington Wizards", "WAS")},
            };

        public static Team GetTeam(string nameIdentifier)
        {
            if (Teams.TryGetValue(nameIdentifier, out var team))
                return team;

            throw new ArgumentException($"Team with NameIdentifier = '{nameIdentifier}' not found");
        }
    }
}