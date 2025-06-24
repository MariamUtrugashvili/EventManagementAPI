using Events.API.Infrastructure.Middlewares;

namespace Events.API.Infrastructure.Extensions
{
    public static class GlobalExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExeptionsMiddleware>();
        }
    }
}
