using Microsoft.EntityFrameworkCore;
using Weather_Application_Backend.Data;
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

    public async Task SaveChanges()
    {
        await this._context.SaveChangesAsync();
    }
}
