using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Repository.MeasurementsRepository
{
    public interface IMeasurementsRepository
    {
        Task<IReadOnlyCollection<Measurement>> get_measurements_between(DateTime from, DateTime to);

        Task<IReadOnlyCollection<Measurement>> get_latest_measurerments();

        Task<ICollection<Measurement>> GetLatestNMeasurementsFromStation(int stationId , int numberOfHours);

        Task<ICollection<Measurement>> GetLatestNMeasurementsFromAllStations(ICollection<int> stationIds, int numberOfHours);

        Task BulkInsert(ICollection<Measurement> measurements);

        Task BulkUpdate(ICollection<Measurement> measurements);
    }
}
