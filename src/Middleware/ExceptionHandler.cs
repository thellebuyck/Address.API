using Address.API.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Address.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ValidationException vex)
            {

                var problemDetails = new
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Failed Validations",
                    Errors = new List<string>()
                };
                

                vex.Errors.ToList().ForEach((error) =>
                {
                    problemDetails.Errors.Add(error.ErrorMessage);
                });
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            catch(NotFoundException notFoundException)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Not found exception",
                    Detail = notFoundException.Message
                };

                context.Response.StatusCode = (int)problemDetails.Status;
                await context.Response.WriteAsJsonAsync(problemDetails);

            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception, "Exception occurred: {Message}", exception.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error"
                };

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

    }
}
