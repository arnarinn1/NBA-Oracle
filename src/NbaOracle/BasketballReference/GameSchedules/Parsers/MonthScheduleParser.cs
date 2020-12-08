using AngleSharp.Dom;
using BuildingBlocks.Parsers;
using NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.Data;

namespace NbaOracle.Providers.BasketballReference.GameSchedules.Parsers
{
    public class MonthScheduleParser : IDocumentParser<MonthScheduleData>
    {
        public MonthScheduleData Parse(IDocument document)
        {
            var output = new MonthScheduleData();

            return output;
        }
    }
}