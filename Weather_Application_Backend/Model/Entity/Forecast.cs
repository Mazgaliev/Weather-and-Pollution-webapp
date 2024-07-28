using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Weather_Application_Backend.Model.Enum;

namespace Weather_Application_Backend.Model.Entity
{
    public class Forecast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ForecastTime { get; set; }

        [Required]
        public TimeType TimeType { get; set; }

        [Required]
        public int StationId { get; set; }

        [ForeignKey("StationId")]
        [Required]
        public Station Station { get; set; }

        public float PM10 { get; set; }

        public float PM2_5 { get; set; }

        public float Humidity { get; set; }

        public float Windspeed { get; set; }

        public float Temperature { get; set; }

        public Forecast() { }
        public Forecast(DateTime forecastTime, TimeType timeType, Station station, float pm10, float pm2_5, float humidity, float windspeed, float temperature)
        {
            this.ForecastTime = forecastTime;
            this.TimeType = timeType;
            this.Station = station;
            this.PM10 = pm10;
            this.PM2_5 = pm2_5;
            this.Humidity = humidity;
            this.Windspeed = windspeed;
            this.Temperature = temperature;
        }
    }
}
