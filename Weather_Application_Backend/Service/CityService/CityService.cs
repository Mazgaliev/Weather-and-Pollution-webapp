using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Service.CityService
{
    public class CityService : ICityService
    {

        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this._cityRepository = cityRepository;
        }
        public async Task<ICollection<City>> find_all_cities()
        {
            return await this._cityRepository.findAll();
        }
    }
}
