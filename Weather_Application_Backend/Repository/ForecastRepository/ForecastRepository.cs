using EFCore.BulkExtensions;
using Weather_Application_Backend.Data;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Repository.ForecastRepository
{
    public class ForecastRepository : IForecastRepository
    {
        private readonly WeatherForecastContext _weatherForecastContext;
        public ForecastRepository(WeatherForecastContext weatherForecastContext)
        {
            this._weatherForecastContext = weatherForecastContext;
        }

        public async Task BulkInsert(ICollection<Forecast> forecasts)
        {
            await Task.Run(() => this._weatherForecastContext.BulkInsert(forecasts));
        }

        public Task<IReadOnlyCollection<Forecast>> get_forecasts_between(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Forecast>> get_latest_forecasts()
        {
            throw new NotImplementedException();
        }
    }
}
