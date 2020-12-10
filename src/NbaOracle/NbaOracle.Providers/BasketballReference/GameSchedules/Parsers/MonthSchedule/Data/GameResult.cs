using System;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.MonthSchedule.Data
{
    public class GameResult
    {
        public GameResult(DateTime gameDate, string visitorTeam, string homeTeam, int visitorPoints, int homePoints, string boxScoreLink, string overtimes, int attendance)
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

        public override string ToString()
        {
            return $"{HomeTeam} {HomePoints} - {VisitorTeam} {VisitorPoints}";
        }
    }
}