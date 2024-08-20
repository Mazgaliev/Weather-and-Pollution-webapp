using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Service.CityService
{
    public interface ICityService
    {
        Task<ICollection<City>> find_all_cities();
        Task<ICollection<Station>> find_all_stations();
        Task<StationDto> find_nearest_station_info(double longitude, double latitude);

    }
}
