namespace Weather_Application_Backend.Model.Dtos
{
    public class ForecastResultDto
    {
        public int stationId { get; set; }

        public DateTime ForecastTime { get; set; }

        public float AQI { get; set; }

        public float CO { get; set; }

        public float PM2_5 { get; set; }

        public float PM10 { get; set; }

        public float SO2 { get; set; }

    }
}
