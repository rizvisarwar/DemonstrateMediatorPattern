using FluentValidation;

namespace DemonstrateMediatorPattern.BusinessLogic.Features.WeatherForecast
{
    public sealed class WeatherForecastValidator : AbstractValidator<WeatherForecastRequest>
    {
        public WeatherForecastValidator()
        {
            RuleFor(r => r.Date).NotEmpty();
        }
    }
}
