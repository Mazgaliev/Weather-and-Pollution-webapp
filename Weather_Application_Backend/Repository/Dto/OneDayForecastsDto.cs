using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Repository.Dto
{
    public class OneDayForecastsDto
    {
        ICollection<Forecast> Forecasts {  get; set; } = new List<Forecast>();
    }
}
