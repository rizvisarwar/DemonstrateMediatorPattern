using DemonstrateMediatorPattern.DataAccess.Entities;
using DemonstrateMediatorPattern.DataAccess.Interfaces;
using System;

namespace DemonstrateMediatorPattern.DataAccess.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        public Forecast GetByDate(string date)
        {
            return new Forecast
            {
                Date = DateTime.Now,
                TemperatureC = 22,
                Summary = "Sunny"
            };
        }
    }
}
