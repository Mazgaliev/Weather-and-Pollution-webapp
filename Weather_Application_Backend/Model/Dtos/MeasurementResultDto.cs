using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
using Weather_Application_Backend.Model.Serializer;

namespace Weather_Application_Backend.Model.Dtos
{
    public class MeasurementResultDto
    {
        public int stationId { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime measurementTime { get; set; }

        public float aqi { get; set; }

        public float co {  get; set; }

        public float pm2_5 { get; set; }

        public float pm10 { get; set; }

        public float so2 { get; set; }
    }
}
