using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Service.CityService
{
    public interface ICityService
    {
        public Task<ICollection<City>> find_all_cities();
    }
}
