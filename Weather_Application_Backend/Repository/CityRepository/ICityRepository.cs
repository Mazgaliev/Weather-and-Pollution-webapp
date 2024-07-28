using System;
using Weather_Application_Backend.Model.Entity;

/// <summary>
/// Summary description for Interface
/// </summary>
public interface ICityRepository
{


    public Task<IReadOnlyCollection<City>> findAll();

    public Task<City> findById(int id);

    public Task<City> findCityByNameLike(string name);
}
