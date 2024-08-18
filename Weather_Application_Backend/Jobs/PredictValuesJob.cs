using System.Text;
using System.Text.Json;
using Weather_Application_Backend.Mappers;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;
using Weather_Application_Backend.Service.CityService;
using Weather_Application_Backend.Service.ForecastService;
using Weather_Application_Backend.Service.MeasurementService;

namespace Weather_Application_Backend.Jobs
{
    public class PredictValuesJob
    {

        private string url = "http://localhost:8000/predict_values/";

        private readonly IMeasurementService _measurementService;
        private readonly IForecastService _forecastService;
        private readonly ICityService _cityService;
        private readonly IAPIDtoMapper _mapperService;

        public PredictValuesJob(IMeasurementService measurementService, ICityService cityService,
            IAPIDtoMapper mapperService, IForecastService forecastService)
        {
            this._measurementService = measurementService;
            this._forecastService = forecastService;
            this._cityService = cityService;
            this._mapperService = mapperService;
        }

        /// <summary>
        /// Predicts the values for all measurements for the last 24 hours and updates the Forecast table
        /// <br></br>
        /// PM10, PM2.5, NO, CO2, SO
        /// </summary>
        /// <returns></returns>
        public async Task predictValues() 
        { 
            ICollection<Station> stations = await this._cityService.find_all_stations();
            ICollection<int> ids = stations.Select(x => x.Id).ToList();

            ICollection<Measurement> measurements = await this._measurementService.GetLatestNMeasurementsFromAllStations(ids, 48);

            ICollection<ForecastResultDto> results = await send_request(measurements);
            ICollection<Forecast> forecasts =  this._mapperService.MapAllForecastsDtos(results);

            await this._forecastService.BulkInsertOrUpdate(forecasts);
        }

        /// <summary>
        /// Sends a request to the API and tries to serialize a result.
        /// </summary>
        /// <param name="station"></param>
        /// <returns>Returns and EMPTY StationMeasurementDto if it is faulty otherwise returns </returns>
        private async Task<ICollection<ForecastResultDto>> send_request(ICollection<Measurement> measurements)
        {
            var client = new HttpClient();

            Dictionary<string, ICollection<Measurement>> content = new Dictionary<string, ICollection<Measurement>> { { "measurements_payload", measurements } };
            var jsonPayload = JsonSerializer.Serialize(content);

            var data = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(this.url, data);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            StationForecastsDto? result = JsonSerializer.Deserialize<StationForecastsDto>(body);


            return result != null ? result.Forecasts : new List<ForecastResultDto>();
        }
    }
}
