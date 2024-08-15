using Microsoft.IdentityModel.Tokens;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Mappers
{
    public class APIDtoMapper : IAPIDtoMapper
    {
        /// <summary>
        /// Takes in a collection of StationMeasurements from the API and maps them to the Measurement CLASS.
        /// </summary>
        /// <param name="measurementDtos"></param>
        /// <returns>ICollection<Measurement></returns>
        public ICollection<Measurement> MapAllMeasurementsToDto(ICollection<StationMeasurementDto> measurementDtos)
        {
            List<Measurement> finalMeasurementList = new List<Measurement>();
            foreach (StationMeasurementDto stationMeasurementDto in measurementDtos)
            {
                if (stationMeasurementDto.Error != true && !stationMeasurementDto.Result.IsNullOrEmpty()) 
                {
                    foreach (MeasurementDto measurementDto in stationMeasurementDto.Result)
                    {
                        finalMeasurementList.Add(MapToEntity(measurementDto));
                    }
                }
            }
            return finalMeasurementList;
        }

        public Measurement MapToEntity(MeasurementDto dto)
        {
            if (dto == null)
            {
                return new Measurement();
            }

            return new Measurement(dto.measurementTime, dto.stationId, dto.aqi,dto.pm10, dto.pm2_5, dto.co, dto.so2);
        }

    }
}
