using Microsoft.AspNetCore.Mvc;

namespace Task4.MiddelWare
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
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
            catch (Exceptions.NotFoundException ex)
            {
                _logger.LogWarning(ex, "Not Found Exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
            catch (Exceptions.ConflictException ex)
            {
                _logger.LogWarning(ex, "Conflict Exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
            catch (Exceptions.DueDateInPastException ex)
            {
                _logger.LogWarning(ex, "Due Date In Past Exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/problem+json";

            var statusCode = exception switch
            {
                Exceptions.NotFoundException => StatusCodes.Status404NotFound,
                Exceptions.ConflictException => StatusCodes.Status409Conflict,
                Exceptions.DueDateInPastException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.StatusCode = statusCode;

            var title = exception switch
            {
                Exceptions.NotFoundException => "Resource not found",
                Exceptions.ConflictException => "Conflict occurred",
                Exceptions.DueDateInPastException => "Validation failed",
                _ => "An unexpected error occurred."
            };

            var problem = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = statusCode == 500
                    ? "Please contact support with your traceId."
                    : exception.Message,
                Instance = context.Request.Path
            };

            return context.Response.WriteAsJsonAsync(problem);
        }
    }
}
