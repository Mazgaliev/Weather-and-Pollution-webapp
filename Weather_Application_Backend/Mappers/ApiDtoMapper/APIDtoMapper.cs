using Microsoft.IdentityModel.Tokens;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Mappers.ApiDtoMapper
{
    public class APIDtoMapper : IAPIDtoMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="forecastsDtos"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ICollection<Forecast> MapAllForecastsDtos(ICollection<ForecastResultDto> forecastsDtos)
        {
            return forecastsDtos.Select(x => MapToEntity(x)).ToList();
        }

        /// <summary>
        /// Takes in a collection of StationMeasurements from the API and maps them to the Measurement CLASS.
        /// </summary>
        /// <param name="measurementDtos"></param>
        /// <returns>ICollection<Measurement></returns>
        public ICollection<Measurement> MapAllMeasurementsDtos(ICollection<StationMeasurementDto> measurementDtos)
        {
            List<Measurement> finalMeasurementList = new List<Measurement>();
            foreach (StationMeasurementDto stationMeasurementDto in measurementDtos)
            {
                if (stationMeasurementDto.Error != true && !stationMeasurementDto.Result.IsNullOrEmpty())
                {
                    foreach (MeasurementResultDto measurementDto in stationMeasurementDto.Result)
                    {
                        finalMeasurementList.Add(MapToEntity(measurementDto));
                    }
                }
            }
            return finalMeasurementList;
        }

        public Measurement MapToEntity(MeasurementResultDto dto)
        {
            if (dto == null)
            {
                return new Measurement();
            }

            return new Measurement(dto.measurementTime, dto.stationId, dto.aqi, dto.pm10, dto.pm2_5, dto.co, dto.so2);
        }

        public Forecast MapToEntity(ForecastResultDto dto)
        {
            if (dto == null)
            {
                return new Forecast();
            }

            return new Forecast(dto.ForecastTime, dto.StationId, dto.PM10, dto.PM2_5, dto.CO, dto.SO2);
        }
    }
}
