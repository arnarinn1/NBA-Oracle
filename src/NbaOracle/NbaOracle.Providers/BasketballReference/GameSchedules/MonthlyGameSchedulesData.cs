using NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.MonthSchedule.Data;

namespace NbaOracle.Providers.BasketballReference.GameSchedules
{
    public class MonthlyGameSchedulesData
    {
        public MonthlyGameSchedulesData(MonthScheduleData schedules)
        {
            Schedules = schedules;
        }

        public MonthScheduleData Schedules { get; }
    }
}