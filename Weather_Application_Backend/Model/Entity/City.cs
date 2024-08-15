using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_Application_Backend.Model.Entity
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public ICollection<Station> Stations { get; set; } = new List<Station>();


        public City() { }
        /// <summary>
        /// Default constructor for City
        /// </summary>
        /// <param name="name">City name</param>
        /// <param name="longitude">longitude coords</param>
        /// <param name="latitude">latitude coords</param>
        /// <param name="stations">A empty or non empty collection of Stations</param>
        public City(string name, string longitude, string latitude, ICollection<Station> stations)
        { 
            this.Name = name;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Stations = stations;
        }
    }
}
