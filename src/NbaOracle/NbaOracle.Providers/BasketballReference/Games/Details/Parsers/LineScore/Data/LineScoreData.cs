using System.Collections.Generic;
using System.Linq;
// ReSharper disable PossibleMultipleEnumeration

namespace NbaOracle.Providers.BasketballReference.Games.Details.Parsers.LineScore.Data
{
    public class LineScoreData
    {
        public LineScoreData(string homeTeam, string visitorTeam, int home1QuarterScore, int home2QuarterScore, int home3QuarterScore, int home4QuarterScore, IEnumerable<OvertimeScoreData> homeOvertimeScores, int visitor1QuarterScore, int visitor2QuarterScore, int visitor3QuarterScore, int visitor4QuarterScore, IEnumerable<OvertimeScoreData> visitorOvertimeScores)
        {
            HomeTeam = homeTeam;
            VisitorTeam = visitorTeam;

            Home1QuarterScore = home1QuarterScore;
            Home2QuarterScore = home2QuarterScore;
            Home3QuarterScore = home3QuarterScore;
            Home4QuarterScore = home4QuarterScore;
            HomeOvertimeScores = homeOvertimeScores;
            HomeTotalScore = TotalScore(home1QuarterScore, home2QuarterScore, home3QuarterScore, home4QuarterScore, homeOvertimeScores);

            Visitor1QuarterScore = visitor1QuarterScore;
            Visitor2QuarterScore = visitor2QuarterScore;
            Visitor3QuarterScore = visitor3QuarterScore;
            Visitor4QuarterScore = visitor4QuarterScore;
            VisitorOvertimeScores = visitorOvertimeScores;
            VisitorTotalScore = TotalScore(visitor1QuarterScore, visitor2QuarterScore, visitor3QuarterScore, visitor4QuarterScore, visitorOvertimeScores);

            WinnerTeam = HomeTotalScore > VisitorTotalScore ? homeTeam : visitorTeam;
            LosingTeam = HomeTotalScore > VisitorTotalScore ? visitorTeam : homeTeam;

            static int TotalScore(int q1, int q2, int q3, int q4, IEnumerable<OvertimeScoreData> overtimes) => q1 + q2 + q3 + q4 + overtimes.Sum(x => x.Score);
        }

        public string HomeTeam { get; }
        public string VisitorTeam { get; }

        public int Home1QuarterScore { get; }
        public int Home2QuarterScore { get; }
        public int Home3QuarterScore { get; }
        public int Home4QuarterScore { get; }
        public IEnumerable<OvertimeScoreData> HomeOvertimeScores { get; }
        public int HomeTotalScore { get; }

        public int Visitor1QuarterScore { get; }
        public int Visitor2QuarterScore { get; }
        public int Visitor3QuarterScore { get; }
        public int Visitor4QuarterScore { get; }
        public IEnumerable<OvertimeScoreData> VisitorOvertimeScores { get; }
        public int VisitorTotalScore { get; }

        public string WinnerTeam { get; }
        public string LosingTeam { get; }
    }
}