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
    }
}
