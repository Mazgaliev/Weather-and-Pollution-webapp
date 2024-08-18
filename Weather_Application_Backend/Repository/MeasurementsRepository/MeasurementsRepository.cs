using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
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
            await Task.Run(() => this._weatherForecastContext.BulkInsertOrUpdateAsync(measurements, options =>
            {
                options.UpdateByProperties = new List<string> { "MeasurementTime", "StationId" };
            }));
        }

        public Task BulkUpdate(ICollection<Measurement> measurements)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Measurement>> GetAllMeasurementsForStation(int stationId)
        {
            return await this._weatherForecastContext.Measurement.Where(m => m.StationId == stationId).ToListAsync();
        }

        /// <summary>
        /// Gets the requested number of hours of measurements for a list of stations.
        /// </summary>
        /// <param name="stationIds"></param>
        /// <param name="numberOfHours"></param>
        /// <returns></returns>
        public async Task<ICollection<Measurement>> GetLatestNMeasurementsFromAllStations(ICollection<int> stationIds, int numberOfHours)
        {
            DateTime endTime = DateTime.Now;
            DateTime startTime = endTime.AddHours(-numberOfHours);

            return await this._weatherForecastContext.Measurement
                .Where(m => stationIds.Contains(m.StationId) && m.MeasurementTime >= startTime && m.MeasurementTime <= endTime)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the requested number of hours of measurements for a station.
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="numberOfHours"></param>
        /// <returns>a list of measurements</returns>
        public async Task<ICollection<Measurement>> GetLatestNMeasurementsFromStation(int stationId, int numberOfHours)
        {
            DateTime endTime = DateTime.Now;
            DateTime startTime = endTime.AddHours(-numberOfHours);
            return await this._weatherForecastContext.Measurement
                .Where(m => m.StationId == stationId && 
                        m.MeasurementTime >= startTime && m.MeasurementTime <= endTime)
                        .ToListAsync();
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
