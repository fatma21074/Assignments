namespace Task5.Maddelware
{
    public class sunsetMiddelware
    {
        private readonly RequestDelegate _next;
        public sunsetMiddelware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            // Check if the request is for a deprecated API version
            if (context.Request.Path.StartsWithSegments("/api/v1"))
            {
                context.Response.Headers["sunset"] = "set to one year from today";
               
            }
            await _next(context);
        }
    }
}
