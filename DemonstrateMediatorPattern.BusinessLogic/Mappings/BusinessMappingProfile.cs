using AutoMapper;
using DemonstrateMediatorPattern.BusinessLogic.Features.WeatherForecast;
using DemonstrateMediatorPattern.DataAccess.Entities;

namespace DemonstrateMediatorPattern.BusinessLogic.Mappings
{
    public class BusinessMappingProfile : Profile
    {
        public BusinessMappingProfile()
        {
            CreateMap<Forecast, WeatherForecastResponse>();
        }
    }
}
