using DemonstrateMediatorPattern.BusinessLogic.Features.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemonstrateMediatorPattern.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MediatingController : ControllerBase
    {
        protected IMediator Mediator { get; }

        protected MediatingController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequestAsync<TRequest, TResponse>(TRequest request)
           where TRequest : RequestBase<TResponse>
           where TResponse : class
        {
            if (request == null) return BadRequest();

            //request.CorrelationId = HttpContext.Request.Headers.GetCorrelationIdFromHeader();

            var response = await Mediator.Send(request);

            return Ok(response);
        }
    }
}