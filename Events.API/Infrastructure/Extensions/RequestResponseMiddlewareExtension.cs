using Events.API.Infrastructure.Middlewares;

namespace Events.API.Infrastructure.Extensions
{
    public static class RequestResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestResponseMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
