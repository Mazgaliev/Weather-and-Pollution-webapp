using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Application_Backend.Model.Entity
{
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime MeasurementTime { get; set; }

        [Required]
        public int StationId { get; set; }

        [ForeignKey("StationId")]
        public Station Station { get; set; }

        public float AQI { get; set; }

        public float PM10 { get; set; }
        
        public float PM2_5 { get; set; }

        public float CO { get; set; }

        public float SO2 { get; set; }

        public Measurement() { }

        public Measurement(DateTime measurementTime, int stationId, float aqi, float pm10, float pm2_5, float co, float so2)
        { 
            this.MeasurementTime = measurementTime;
            this.AQI = aqi;
            this.StationId = stationId;
            this.PM10 = pm10;
            this.PM2_5 = pm2_5;
            this.CO = co;
            this.SO2 = so2;
        }
    }
}
