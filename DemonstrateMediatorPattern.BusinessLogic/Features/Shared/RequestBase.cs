using MediatR;

namespace DemonstrateMediatorPattern.BusinessLogic.Features.Shared
{
    public abstract class RequestBase<TResponse> : IRequest<TResponse> where TResponse : class
    {
    }
}
