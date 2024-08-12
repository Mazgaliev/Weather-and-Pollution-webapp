using System.Configuration;
using System.Text.Json.Nodes;
using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Repository.MeasurementsRepository;

namespace Weather_Application_Backend.Jobs
{
    public class OpenWeatherMapApiJob
    {
        private string url = "http://api.openweathermap.org/data/2.5/air_pollution/history";
        private readonly string api_key = System.Configuration.ConfigurationManager.AppSettings["openweatherapikey"];
        private readonly IMeasurementsRepository _measurementsRepository;

        public OpenWeatherMapApiJob(IMeasurementsRepository measurementsRepository)
        {
            this._measurementsRepository = measurementsRepository;
        }
        /// <summary>
        /// Scrapes data from http://api.openweathermap.org/.
        /// <br></br>
        /// Sends a get request to a simple django server that processes the requests 
        /// </summary>
        /// <returns></returns>
        public Task scrapeData() 
        {
            DateTimeOffset.Now.ToUnixTimeSeconds();

            System.Console.WriteLine("Some wild data that occurs every minute lmfao");

            try
            {
                //send_request(new Station());
            }
            catch (HttpRequestException requestException)
            {
                // Do something if error happens lmfao
            }
            return Task.CompletedTask;
        }


        private async Task send_request(Station station)
        {

            string start = DateTimeOffset.Now.AddHours(-24).ToUnixTimeSeconds().ToString();
            string end = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();

            var client = new HttpClient();
            this.url += $"?lat={station.Latitude}&lon={station.Longitude}&type=hour&start={start}&end={end}&appid={this.api_key}";
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = (JsonObject)JsonNode.Parse(body);
                Console.WriteLine(body);
            }

            return ;
        }

        private ICollection<Measurement> parse_response(JsonObject jsonResponse)
        {

            return new List<Measurement>();
        }

    }
}
