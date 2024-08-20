using Microsoft.EntityFrameworkCore;
using Weather_Application_Backend.Data;
using Weather_Application_Backend.Model.Dtos;
using Weather_Application_Backend.Model.Entity;
/// <summary>
/// Summary description for Class1
/// </summary>
public class CityRepository : ICityRepository
{

	private readonly WeatherForecastContext _context;
	public CityRepository(WeatherForecastContext context)
	{
		this._context = context;
	}

    public async Task<ICollection<City>> findAll()
    {
        return await this._context.Cities.Include(c => c.Stations).ToListAsync();
    }

    public async Task<City?> findById(int id)
    {
        return await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<City> findCityByNameLike(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Station>> find_all_stations()
    {
        return await this._context.Stations.ToListAsync();
    }

    public async Task<Station?> find_nearest_station(double longitude, double latitude)
    {
        DateTime endTime = DateTime.Now;
        DateTime startTime = endTime.AddHours(-24);
        return await this._context.Stations
        .Include(s=>s.Measurements.Where(m => m.MeasurementTime >= startTime))
        .Include(s => s.Forecasts.Where(f => f.ForecastTime>= endTime))
        .OrderBy(s =>
            6341 * 2 * Math.Asin(Math.Sqrt(
                Math.Pow(Math.Sin((Math.PI / 180 * s.Latitude - Math.PI / 180 * latitude) / 2), 2) +
                Math.Cos(Math.PI / 180 * latitude) * Math.Cos(Math.PI / 180 * s.Latitude) *
                Math.Pow(Math.Sin((Math.PI / 180 * s.Longitude - Math.PI / 180 * longitude) / 2), 2)
            ))
        )
        .FirstOrDefaultAsync();
    }

    private static double ToRadians(double deg)
    {
        return Math.PI/180 * deg;
    }

        public async Task SaveChanges()
    {
        await this._context.SaveChangesAsync();
    }

}
