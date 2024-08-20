using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Mappers.ApiDtoMapper
{
    public interface IAPIDtoMapper
    {
        public Measurement MapToEntity(MeasurementResultDto dto);

        public ICollection<Measurement> MapAllMeasurementsDtos(ICollection<StationMeasurementDto> measurementDtos);

        public Forecast MapToEntity(ForecastResultDto dto);

        public ICollection<Forecast> MapAllForecastsDtos(ICollection<ForecastResultDto> forecastsDtos);
    }
}
