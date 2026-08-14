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
        public static Task Invoke(HttpContext context, RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            var globalException = new GlobalExceptionHandler(next, logger);
            return globalException.InvokeAsync(context);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                Exceptions.NotFoundException => StatusCodes.Status404NotFound,
                Exceptions.ConflictException => StatusCodes.Status409Conflict,
                Exceptions.DueDateInPastException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
            var result = new
            {
                error = exception.Message,
                statusCode = context.Response.StatusCode
            };
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
