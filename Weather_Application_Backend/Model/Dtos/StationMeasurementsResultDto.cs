namespace Weather_Application_Backend.Model.Dtos
{
    public class StationMeasurementsResultDto
    {
       public ICollection<StationMeasurementDto> Result { get; set; } = new List<StationMeasurementDto>();
    }
}
