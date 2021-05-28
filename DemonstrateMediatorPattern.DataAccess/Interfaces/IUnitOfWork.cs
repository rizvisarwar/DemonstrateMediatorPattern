using System;
using System.Collections.Generic;
using System.Text;

namespace DemonstrateMediatorPattern.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IWeatherRepository Forecasts { get; set; }
    }
}
