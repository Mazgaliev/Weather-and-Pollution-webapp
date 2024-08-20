using Weather_Application_Backend.Mappers.ApiDtoMapper;
using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Repository.MeasurementsRepository;

namespace Weather_Application_Backend.Service.MeasurementService
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementsRepository _measurementsRepository;
        private readonly IAPIDtoMapper _APIDtoMapper;
        public MeasurementService(IMeasurementsRepository measurementsRepository)
        {
           this._measurementsRepository = measurementsRepository;
        }

        /// <summary>
        /// Bulk INSERTS OR UPDATES, based on the Measuremnt DateTime and station ID
        /// If a record exists fora  combination of station ID and MeasuremntTime then it is updated with the new values.
        /// </summary>
        /// <param name="measurements"></param>
        /// <returns></returns>
        public async Task BulkInsertOrUpdate(ICollection<Measurement> measurements)
        {
            await this._measurementsRepository.BulkInsertOrUpdate(measurements);
        }

        public async Task<ICollection<Measurement>> GetAllMeasurementsFromStation(int stationId)
        {
            return await this._measurementsRepository.GetAllMeasurementsForStation(stationId);
        }

        public async Task<ICollection<Measurement>> GetLatestNMeasurementsFromAllStations(ICollection<int> stationIds, int numberOfHours)
        {
            return await this._measurementsRepository.GetLatestNMeasurementsFromAllStations(stationIds, numberOfHours);
        }

        public async Task<ICollection<Measurement>> GetLatestNMeasurementsFromStation(int stationId, int numberOfHours)
        {
            return await this._measurementsRepository.GetLatestNMeasurementsFromStation(stationId, numberOfHours);
        }
    }
}
