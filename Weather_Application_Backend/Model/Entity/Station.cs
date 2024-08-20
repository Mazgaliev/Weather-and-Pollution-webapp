using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Weather_Application_Backend.Model.Entity
{
    public class Station
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        [Required]
        [JsonIgnore]
        public City City { get; set; }

        public ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

        public ICollection<Forecast> Forecasts { get; set; } = new List<Forecast>();

        public Station(string name, double latitude, double longitude)
        {
            this.Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
