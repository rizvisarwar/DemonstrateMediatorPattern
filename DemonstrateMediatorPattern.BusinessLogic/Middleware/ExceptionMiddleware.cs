using DemonstrateMediatorPattern.BusinessLogic.Exceptions;
using DemonstrateMediatorPattern.BusinessLogic.Extensions;
using DemonstrateMediatorPattern.BusinessLogic.Features.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DemonstrateMediatorPattern.BusinessLogic.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ExceptionMiddleware(
            RequestDelegate next,
            IConfiguration configuration
            )
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // Let the delegate execute down the middleware pipeline
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);

                //LogException(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            var errorResponse = new ErrorDetailsResponse
            {
                CorrelationId = httpContext.Request.Headers.GetCorrelationIdFromHeader()
            };

            if (exception.GetType() == typeof(BusinessException))
            {
                var bException = (BusinessException)exception;

                errorResponse.Code = bException.Code;
                if (bException.HttpStatusCode.HasValue)
                {
                    httpStatusCode = bException.HttpStatusCode.Value;
                }
            }

            if (_configuration.GetValue<bool>("ReturnErrorMessages"))
            {
                if (exception.GetType() == typeof(ValidationException))
                {
                    var vException = (ValidationException)exception;

                    errorResponse.Messages = vException.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var message = !string.IsNullOrEmpty(exception.Message) ? exception.Message : "Internal Server Error";
                    errorResponse.Messages = new List<string> { message };
                }

                errorResponse.InnerMessage = exception.InnerException?.Message;
            }

            httpContext.Response.StatusCode = (int)httpStatusCode;
            httpContext.Response.ContentType = "application/json";
            return httpContext.Response.WriteAsync(errorResponse.SerializeObject());
        }
    }
}
