using AutoMapper;
using DemonstrateMediatorPattern.BusinessLogic.Exceptions;
using DemonstrateMediatorPattern.BusinessLogic.Features.Shared;
using DemonstrateMediatorPattern.DataAccess.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DemonstrateMediatorPattern.BusinessLogic.Features.WeatherForecast
{
    public class WeatherForecastHandler : MediatingRequestHandler<WeatherForecastRequest, WeatherForecastResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeatherForecastHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<WeatherForecastResponse> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var forecast = _unitOfWork.Forecasts.GetByDate(request.Date);

            if (forecast == null)
            {
                throw new BusinessException($"Couldn't find any weather info", 1001, System.Net.HttpStatusCode.InternalServerError);
            }

            var response = _mapper.Map<WeatherForecastResponse>(forecast);

            return await Task.FromResult(response);
        }
    }
}
