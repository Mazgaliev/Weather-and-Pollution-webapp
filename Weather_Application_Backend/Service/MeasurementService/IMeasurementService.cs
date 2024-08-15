using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Service.MeasurementService
{
    public interface IMeasurementService
    {
        void BulkUpdate();

        Task BulkInsert(ICollection<Measurement> measurements);
    }
}
