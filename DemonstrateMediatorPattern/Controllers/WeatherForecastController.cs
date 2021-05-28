using DemonstrateMediatorPattern.BusinessLogic.Features.WeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemonstrateMediatorPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : MediatingController
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("/weatherForecast")]
        public async Task<IActionResult> Get(string date)
        {
            return await HandleRequestAsync<WeatherForecastRequest, WeatherForecastResponse>(new WeatherForecastRequest { Date = date });
        }
    }
}
