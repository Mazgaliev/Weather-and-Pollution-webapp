using System.Text;
using System.Text.Json;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Service.MeasurementService;

namespace Weather_Application_Backend.Jobs
{
    public class RetrainModelsJob
    {
        private string url = "http://localhost:8000/train_models/";
        private readonly IMeasurementService _measurementService;

        public RetrainModelsJob(IMeasurementService measurementService)
        {
            this._measurementService = measurementService;
        }
        /// <summary>
        /// Re - train the models on data from the last week including the new gathered data.
        /// </summary>
        /// <returns></returns>
        public async Task trainModels()
        {

            ICollection<Measurement> measurements = await this._measurementService.GetAllMeasurementsFromStation(1);

            try
            {
                await send_request(measurements);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Error training models");

            }
        }
        private async Task send_request(ICollection<Measurement> measurements)
        {
            var client = new HttpClient();

            Dictionary<string, ICollection<Measurement>> content = new Dictionary<string, ICollection<Measurement>> { { "measurements_payload", measurements } };
            var jsonPayload = JsonSerializer.Serialize(content);

            var data = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(this.url, data);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            StationForecastsDto? result = JsonSerializer.Deserialize<StationForecastsDto>(body);

        }
    }
}
