using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Repository.ForecastRepository;

namespace Weather_Application_Backend.Service.ForecastService
{
    public class ForecastService : IForecastService
    {
        private readonly IForecastRepository _forecastRepository;

        public ForecastService(IForecastRepository forecastRepository)
        {
           this._forecastRepository = forecastRepository;
        }

        public async Task BulkInsertOrUpdate(ICollection<Forecast> forecasts)
        {
            await this._forecastRepository.BulkInsertOrUpdate(forecasts);
        }
    }
}
