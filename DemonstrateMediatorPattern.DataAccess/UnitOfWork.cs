using DemonstrateMediatorPattern.DataAccess.Interfaces;
using System;

namespace DemonstrateMediatorPattern.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IWeatherRepository Forecasts { get; set; }

        public UnitOfWork(IWeatherRepository forecasts) : base()
        {
            Forecasts = forecasts;
        }
    }
}
