using System;
using System.Threading.Tasks;
using BuildingBlocks.DocumentLoaders;
using NbaOracle.Providers.BasketballReference.GameSchedules.Parsers.MonthSchedule;
using ValueObjects;

namespace NbaOracle.Providers.BasketballReference.GameSchedules
{
    public class MonthlyGameSchedulesProvider : IMonthlyGameSchedulesProvider
    {
        private readonly IDocumentLoader _documentLoader;
        private readonly MonthlyGameSchedulesProviderSettings _settings;

        private readonly MonthScheduleParser _monthScheduleParser;

        public MonthlyGameSchedulesProvider(IDocumentLoader documentLoader, MonthlyGameSchedulesProviderSettings settings)
        {
            _documentLoader = documentLoader ?? throw new ArgumentNullException(nameof(documentLoader));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));

            _monthScheduleParser = new MonthScheduleParser();
        }

        public async Task<MonthlyGameSchedulesData> GetSchedule(Season season, Month month)
        {
            var document = await _documentLoader.LoadDocument(_settings.ToDocumentOptions(season, month));

            var monthSchedule = _monthScheduleParser.Parse(document);

            return new MonthlyGameSchedulesData(monthSchedule);
        }
    }
}