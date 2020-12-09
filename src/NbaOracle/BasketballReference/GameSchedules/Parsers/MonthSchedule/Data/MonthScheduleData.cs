using System;
using System.Collections.Generic;

namespace NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.MonthSchedule.Data
{
    public class MonthScheduleData
    {
        public MonthScheduleData()
        {
            GameResults = new List<GameResult>();
        }

        public ICollection<GameResult> GameResults { get; }

        public void AddGameResult(GameResult gameResult)
        {
            if (gameResult == null) 
                throw new ArgumentNullException(nameof(gameResult)); 
            
            GameResults.Add(gameResult);
        }
    }
}