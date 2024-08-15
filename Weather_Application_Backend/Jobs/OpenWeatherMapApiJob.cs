using Newtonsoft.Json.Converters;
using System.Text;
using System.Text.Json;
using Weather_Application_Backend.Mappers;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Repository.MeasurementsRepository;
using Weather_Application_Backend.Service.CityService;
using Weather_Application_Backend.Service.MeasurementService;

namespace Weather_Application_Backend.Jobs
{
    public class OpenWeatherMapApiJob
    {
        private string url = "http://localhost:8000/scrape_data/";
        private readonly IMeasurementService _measurementService;
        private readonly ICityService _cityService;
        private readonly IAPIDtoMapper _mapper;
        public OpenWeatherMapApiJob(IMeasurementService measurementService, ICityService cityService, IAPIDtoMapper mapper)
        {
            this._measurementService = measurementService;
            this._cityService = cityService;
            this._mapper = mapper;

        }
        /// <summary>
        /// Scrapes data from http://api.openweathermap.org/.
        /// <br></br>
        /// Sends a get request to a simple django server that processes data from openweathermap API
        /// </summary>
        /// <returns></returns>
        public async Task scrapeData() 
        {

            ICollection<City> cities = await this._cityService.find_all_cities();
            ICollection<Station> stations = await this._cityService.find_all_stations();

            ICollection<StationMeasurementDto> api_measurements =  await send_request(stations);

            ICollection<Measurement> parsed_api_measurements = this._mapper.MapAllMeasurementsToDto(api_measurements);

            await this._measurementService.BulkInsert(parsed_api_measurements);
            // await this._cityRepository.SaveChanges();

        }

        /// <summary>
        /// Sends a request to the API and tries to serialize a result.
        /// </summary>
        /// <param name="station"></param>
        /// <returns>Returns and EMPTY StationMeasurementDto if it is faulty otherwise returns </returns>
        private async Task<ICollection<StationMeasurementDto>> send_request(ICollection<Station> stations)
        {
            var client = new HttpClient();

            Dictionary<string, ICollection<Station>> content = new Dictionary<string, ICollection<Station>>{ {"stations_payload", stations } };
            var jsonPayload = JsonSerializer.Serialize(content);

            var data = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(this.url, data);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            StationMeasurementsResultDto? result = JsonSerializer.Deserialize<StationMeasurementsResultDto>(body);


            return result != null? result.Result: new List<StationMeasurementDto> ();
        }
    }
}
