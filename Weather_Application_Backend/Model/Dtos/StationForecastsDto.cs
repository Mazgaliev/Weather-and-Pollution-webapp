﻿namespace Weather_Application_Backend.Model.Dtos
{
    public class StationForecastsDto
    {
        public ICollection<ForecastResultDto> Forecasts { get; set; } = new List<ForecastResultDto>();
    }
}
