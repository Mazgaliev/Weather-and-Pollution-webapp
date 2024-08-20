using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Mappers.DBResultMapper
{
    public interface IDBResultMapper
    {
        public StationDto MapStationDbResultToStationDto(Station station);
    }
}
