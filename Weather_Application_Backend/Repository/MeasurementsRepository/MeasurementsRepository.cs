using EFCore.BulkExtensions;
using Weather_Application_Backend.Data;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Repository.MeasurementsRepository
{
    public class MeasurementsRepository : IMeasurementsRepository
    {
        private readonly WeatherForecastContext _weatherForecastContext;
        public MeasurementsRepository(WeatherForecastContext weatherForecastContext)
        {
            this._weatherForecastContext = weatherForecastContext;
        }

        public async Task BulkInsert(ICollection<Measurement> measurements)
        {
            await Task.Run(() => this._weatherForecastContext.BulkInsert(measurements));
        }

        public Task BulkUpdate(ICollection<Measurement> measurements)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the measurements for the last 24 hours
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IReadOnlyCollection<Measurement>> get_latest_measurerments()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets measurements between a given interval
        /// </summary>
        /// <param name="from">The starting interval</param>
        /// <param name="to">The ending interval</param>
        /// <returns>A read only collection of measurements</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IReadOnlyCollection<Measurement>> get_measurements_between(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

    }
}
