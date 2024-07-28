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
		//
		// TODO: Add constructor logic here
		//
		this._context = context;
	}

    public async Task<IReadOnlyCollection<City>> findAll()
    {
        return await this._context.Cities.Include(c => c.Stations).ToListAsync();
    }

    public Task<City> findById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<City> findCityByNameLike(string name)
    {
        throw new NotImplementedException();
    }
}
