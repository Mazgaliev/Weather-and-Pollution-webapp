using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Application_Backend.Model.Entity
{
    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("CityId")]
        [Required]
        public City City { get; set; }

        public ICollection<Measurement> Measurements { get; set; }

        public ICollection<Forecast> Forecasts { get; set; }        
        public Station(string name)
        {
            this.Name = name;
        }
    }
}
