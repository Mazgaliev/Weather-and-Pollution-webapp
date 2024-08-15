using Newtonsoft.Json.Converters;
using System.Text.Json;
using Weather_Application_Backend.Mappers;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Repository.MeasurementsRepository;
using Weather_Application_Backend.Service.MeasurementService;

namespace Weather_Application_Backend.Jobs
{
    public class OpenWeatherMapApiJob
    {
        private string url = "http://localhost:8000/scrape_data/";
        private readonly IMeasurementService _measurementService;
        private readonly ICityRepository _cityRepository;
        private readonly IAPIDtoMapper _mapper;
        public OpenWeatherMapApiJob(IMeasurementService measurementService, ICityRepository cityRepository, IAPIDtoMapper mapper)
        {
            this._measurementService = measurementService;
            this._cityRepository = cityRepository;
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

            ICollection<City> cities = await this._cityRepository.findAll();
            List<StationMeasurementDto> api_measurements = new List<StationMeasurementDto>();

            foreach (City city in cities)
            {
                foreach (Station station in city.Stations)
                {
                    try
                    {
                        api_measurements.Add(await send_request(station));
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex);
                    }
                }
            }

            ICollection<Measurement> parsed_api_measurements = this._mapper.MapAllMeasurementsToDto(api_measurements);

            await this._measurementService.BulkInsert(parsed_api_measurements);
            await this._cityRepository.SaveChanges();

        }

        /// <summary>
        /// Sends a request to the API and tries to serialize a result.
        /// </summary>
        /// <param name="station"></param>
        /// <returns>Returns and EMPTY StationMeasurementDto if it is faulty otherwise returns </returns>
        private async Task<StationMeasurementDto> send_request(Station station)
        {
            var client = new HttpClient();

            Dictionary<string, string> content = new Dictionary<string, string>{ { "latitude", station.Latitude.ToString() },
                {"longitude", station.Longitude.ToString() }, { "stationId", station.Id.ToString() } };

            var data = new FormUrlEncodedContent(content);

            var response = await client.PostAsync(this.url, data);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            StationMeasurementDto? result = JsonSerializer.Deserialize<StationMeasurementDto>(body);


            return result!=null?result: new StationMeasurementDto { };
        }
    }
}
