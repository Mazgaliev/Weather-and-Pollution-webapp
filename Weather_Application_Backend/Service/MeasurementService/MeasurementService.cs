using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Repository.MeasurementsRepository;

namespace Weather_Application_Backend.Service.MeasurementService
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementsRepository _measurementsRepository;
        public MeasurementService(IMeasurementsRepository measurementsRepository)
        {
           this._measurementsRepository = measurementsRepository;
        }

        public async Task BulkInsert(ICollection<Measurement> measurements)
        {
            await this._measurementsRepository.BulkInsert(measurements);
        }

        public void BulkUpdate()
        {
            throw new NotImplementedException();
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
