using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Weather_Application_Backend.Model.Entity
{
    public class WeatherAppLogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string message { get; set; } = string.Empty;


        public WeatherAppLogs(string message)
        {
            CreatedOn = DateTime.Now;
            this.message = message;
        }
    }
}
