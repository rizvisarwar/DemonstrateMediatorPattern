using DemonstrateMediatorPattern.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemonstrateMediatorPattern.DataAccess.Interfaces
{
    public interface IWeatherRepository : IBaseRepository<Forecast>
    {
        Forecast GetByDate(string date);
    }
}
