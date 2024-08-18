using System.Text.Json.Serialization;
using Weather_Application_Backend.Model.Serializer;

namespace Weather_Application_Backend.Model.Dtos
{
    public class ForecastResultDto
    {
        public int StationId { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]

        public DateTime ForecastTime { get; set; }

        public float CO { get; set; }

        public float PM2_5 { get; set; }

        public float PM10 { get; set; }

        public float SO2 { get; set; }

    }
}
