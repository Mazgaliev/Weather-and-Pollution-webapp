﻿using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Service.ForecastService
{
    public interface IForecastService
    {
        Task BulkInsertOrUpdate(ICollection<Forecast> forecasts);

    }
}
