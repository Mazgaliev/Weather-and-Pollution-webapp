using Weather_Application_Backend.Model.Serializer;

namespace Weather_Application_Backend.Controllers.Dto
{
    public class ForecastDto
    {
        public DateTime ForecastTime { get; set; }

        public float CO { get; set; }

        public float PM2_5 { get; set; }

        public float PM10 { get; set; }

        public float SO2 { get; set; }

    }
}
