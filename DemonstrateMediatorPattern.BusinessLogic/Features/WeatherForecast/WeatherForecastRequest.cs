using DemonstrateMediatorPattern.BusinessLogic.Features.Shared;

namespace DemonstrateMediatorPattern.BusinessLogic.Features.WeatherForecast
{
    public class WeatherForecastRequest : RequestBase<WeatherForecastResponse>
    {
        public string Date { get; set; }
    }
}
