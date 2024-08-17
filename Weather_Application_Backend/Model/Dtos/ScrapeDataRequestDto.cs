using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Model.Dtos
{
    /// <summary>
    /// Number of hours is the number of hours back that the Openweather API should go back
    /// </summary>
    public class ScrapeDataRequestDto
    {
        public ICollection<Station> Stations { get; set; } = new List<Station>();

        public int NumberOfHours { get; set; }
    }
}
