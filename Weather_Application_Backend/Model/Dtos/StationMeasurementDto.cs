namespace Weather_Application_Backend.Model.Dtos
{
    public class StationMeasurementDto
    {
        public string? Message { get; set; }

        public bool ?Error { get; set; }

        public ICollection<MeasurementResultDto> Result {get; set;} = new List<MeasurementResultDto>();
    }
}
