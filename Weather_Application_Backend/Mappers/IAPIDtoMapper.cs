using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Mappers
{
    public interface IAPIDtoMapper
    {
        public Measurement MapToEntity(MeasurementDto dto);

        public ICollection<Measurement> MapAllMeasurementsToDto(ICollection<StationMeasurementDto> measurementDtos);
    }
}
