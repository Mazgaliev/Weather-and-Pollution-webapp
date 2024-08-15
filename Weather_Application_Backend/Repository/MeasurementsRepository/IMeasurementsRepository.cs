using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Repository.MeasurementsRepository
{
    public interface IMeasurementsRepository
    {
        Task<IReadOnlyCollection<Measurement>> get_measurements_between(DateTime from, DateTime to);

        Task<IReadOnlyCollection<Measurement>> get_latest_measurerments();

        Task BulkInsert(ICollection<Measurement> measurements);

        Task BulkUpdate(ICollection<Measurement> measurements);
    }
}
