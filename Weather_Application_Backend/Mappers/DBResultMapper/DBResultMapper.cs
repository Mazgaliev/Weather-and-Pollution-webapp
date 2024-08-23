using Weather_Application_Backend.Controllers.Dto;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Mappers.DBResultMapper
{
    public class DBResultMapper : IDBResultMapper
    {
        public StationDto MapStationDbResultToStationDto(Station station, City city)
        {
            StationDto dto = new StationDto();

            dto.Id = station.Id;
            dto.CityName = city.Name;
            dto.StationName = station.Name;
            dto.Longitude = station.Longitude;
            dto.Latitude = station.Latitude;
            dto.Forecasts = station.Forecasts.Select(MapToForecastToDto).ToList();
            dto.Measurements = station.Measurements.Select(MapToMeasurementToDto).ToList();

            return dto;
        }


        private MeasurementDto MapToMeasurementToDto(Measurement measurement)
        {
            return new MeasurementDto 
            { 
                MeasurementTime = measurement.MeasurementTime,
                AQI = (float)measurement.AQI,
                CO = measurement.CO,
                PM10 = measurement.PM10,
                PM2_5 = measurement.PM2_5,
                SO2 = measurement.SO2
            };
        }

        private ForecastDto MapToForecastToDto(Forecast forecast)
        {
            return new ForecastDto
            {
                ForecastTime = forecast.ForecastTime,
                CO = forecast.CO,
                PM10 = forecast.PM10,
                PM2_5 = forecast.PM2_5,
                SO2 = forecast.SO2,
            };
        }
    }
}
