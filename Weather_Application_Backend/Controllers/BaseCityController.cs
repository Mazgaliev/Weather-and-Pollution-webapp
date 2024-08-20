using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Service.CityService;

namespace Weather_Application_Backend.Controllers
{
    [Route("api/city/")]
    [ApiController]
    public class BaseCityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public BaseCityController(ICityService cityService)
        {
            this._cityService = cityService;
        }


        [HttpGet("all")]

        public async Task<ActionResult<ICollection<City>>> GetCities() 
        {
            ICollection<City> cities = await this._cityService.find_all_cities();
            return Ok(cities);
        }


        [HttpGet("nearest")]
        public async Task<ActionResult<Station>> GetNearestLocationInfo(double longitude, double latitude)
        {

            StationDto station =  await this._cityService.find_nearest_station_info(longitude, latitude);
            return Ok(station);
        }
    }
}
