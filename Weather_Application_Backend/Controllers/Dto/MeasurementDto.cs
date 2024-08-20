namespace Weather_Application_Backend.Controllers.Dto
{
    public class MeasurementDto
    {
        public DateTime MeasurementTime { get; set; }

        public float AQI { get; set; }

        public float PM10 { get; set; }

        public float PM2_5 { get; set; }

        public float CO { get; set; }

        public float SO2 { get; set; }
    }
}
