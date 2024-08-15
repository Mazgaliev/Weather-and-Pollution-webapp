using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Repository.ForecastRepository
{
    public interface IForecastRepository
    {
        Task<IReadOnlyCollection<Forecast>> get_forecasts_between(DateTime from, DateTime to);

        Task<IReadOnlyCollection<Forecast>> get_latest_forecasts();

        Task BulkInsert(ICollection<Forecast> forecasts);

    }
}
