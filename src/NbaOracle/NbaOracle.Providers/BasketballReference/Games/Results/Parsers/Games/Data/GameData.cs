using System;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.Games.Results.Parsers.Games.Data
{
    public class GameData
    {
        public GameData(DateTime gameDate, string visitorTeam, string homeTeam, int visitorPoints, int homePoints, string boxScoreLink, string overtimes, int attendance)
        {
            GameDate = gameDate;
            VisitorTeam = visitorTeam;
            HomeTeam = homeTeam;
            WinningTeam = homePoints > visitorPoints ? homeTeam : visitorTeam;
            VisitorPoints = visitorPoints;
            HomePoints = homePoints;
            BoxScoreLink = boxScoreLink;
            NumberOfOvertimes = new Overtime(overtimes).Count;
            Attendance = attendance;
            IsPlayoffGame = new IsPlayoffGame(gameDate);
        }

        public DateTime GameDate { get; }
        
        public string VisitorTeam { get; }
        public string HomeTeam { get; }
        public string WinningTeam { get; }
        
        public int VisitorPoints { get; }
        public int HomePoints { get; }

        public string BoxScoreLink { get; }

        public int? NumberOfOvertimes { get; }
        public int Attendance { get; }

        public bool IsPlayoffGame { get; }

        public override string ToString()
        {
            return $"{HomeTeam} {HomePoints} - {VisitorTeam} {VisitorPoints}";
        }
    }
}