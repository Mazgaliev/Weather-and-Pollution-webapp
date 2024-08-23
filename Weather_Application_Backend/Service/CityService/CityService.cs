using Weather_Application_Backend.Mappers.DBResultMapper;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Service.CityService
{
    public class CityService : ICityService
    {

        private readonly ICityRepository _cityRepository;
        private readonly IDBResultMapper _dBResultMapper;
        public CityService(ICityRepository cityRepository, IDBResultMapper dBResultMapper)
        {
            this._cityRepository = cityRepository;
            this._dBResultMapper = dBResultMapper;
        }
        public async Task<ICollection<City>> find_all_cities()
        {
            return await this._cityRepository.findAll();
        }

        public async Task<ICollection<Station>> find_all_stations()
        {
           return await this._cityRepository.find_all_stations();
        }


        public async Task<StationDto> find_nearest_station_info(double longitude, double latitude)
        {
            Station? station = await this._cityRepository.find_nearest_station(longitude, latitude);
            if (station == null) {
                throw new Exception();
            }

            City? city =  await this._cityRepository.findById(station.CityId);

            if (city == null)
            {
                throw new Exception();
            }
            StationDto dto = this._dBResultMapper.MapStationDbResultToStationDto(station, city);

            return dto;
        }
    }
}
