using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Service.CityService
{
    public interface ICityService
    {
        Task<ICollection<City>> find_all_cities();
        Task<ICollection<Station>> find_all_stations();

    }
}
