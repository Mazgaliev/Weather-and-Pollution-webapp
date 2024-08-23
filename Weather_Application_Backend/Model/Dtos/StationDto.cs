using Weather_Application_Backend.Controllers.Dto;

namespace Weather_Application_Backend.Model.Dtos
{
    public class StationDto
    {
        public int Id { get; set; }

        public string CityName { get; set; } = String.Empty;
        
        public string StationName { get; set; } = String.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ICollection<MeasurementDto> Measurements { get; set; }
        public ICollection<ForecastDto> Forecasts { get; set; }

    }
}
