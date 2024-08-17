using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Service.MeasurementService
{
    public interface IMeasurementService
    {
        Task BulkInsert(ICollection<Measurement> measurements);

        Task<ICollection<Measurement>> GetLatestNMeasurementsFromStation(int stationId, int numberOfHours);

        Task<ICollection<Measurement>> GetLatestNMeasurementsFromAllStations(ICollection<int> stationIds, int numberOfHours);

        Task<ICollection<Measurement>> GetAllMeasurementsFromStation(int stationId);


    }
}
