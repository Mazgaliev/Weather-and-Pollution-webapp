using Azure.Core;
using System.Configuration;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Repository.MeasurementsRepository;

namespace Weather_Application_Backend.Jobs
{
    public class OpenWeatherMapApiJob
    {
        private string url = "http://localhost:8000/scrape_data/";
        private readonly IMeasurementsRepository _measurementsRepository;
        private readonly ICityRepository _cityRepository;
        public OpenWeatherMapApiJob(IMeasurementsRepository measurementsRepository, ICityRepository cityRepository)
        {
            this._measurementsRepository = measurementsRepository;
            this._cityRepository = cityRepository;

        }
        /// <summary>
        /// Scrapes data from http://api.openweathermap.org/.
        /// <br></br>
        /// Sends a get request to a simple django server that processes the requests 
        /// </summary>
        /// <returns></returns>
        public async Task scrapeData() 
        {

            ICollection<City> cities = await this._cityRepository.findAll();
            List<StationMeasurementDto> api_measurements = new List<StationMeasurementDto>();
            DateTimeOffset.Now.ToUnixTimeSeconds();

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
        }

        private async Task<StationMeasurementDto> send_request(Station station)
        {
            var client = new HttpClient();

            Dictionary<string, string> content = new Dictionary<string, string>{ { "latitude", station.Latitude.ToString() }, {"longitude", station.Longitude.ToString() } };
            var data = new FormUrlEncodedContent(content);


            var response = await client.PostAsync(this.url, data);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            StationMeasurementDto? result = JsonSerializer.Deserialize<StationMeasurementDto>(body);

            return result == null? new StationMeasurementDto { } : result;
        }
    }
}
