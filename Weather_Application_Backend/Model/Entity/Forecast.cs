using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Application_Backend.Model.Entity
{
    public class Forecast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime ForecastTime { get; set; }

        [Required]
        public int StationId { get; set; }

        [ForeignKey("StationId")]
        [Required]
        public Station Station { get; set; }

        public float PM10 { get; set; }

        public float PM2_5 { get; set; }

        public float CO { get; }

        public float SO2 { get; }

        public Forecast() { }
        public Forecast(DateTime forecastTime, Station station, float pm10, float pm2_5, float co, float so2)
        {
            this.ForecastTime = forecastTime;
            this.Station = station;
            this.PM10 = pm10;
            this.PM2_5 = pm2_5;
            this.CO = co;
            this.SO2= so2;
        }
    }
}
