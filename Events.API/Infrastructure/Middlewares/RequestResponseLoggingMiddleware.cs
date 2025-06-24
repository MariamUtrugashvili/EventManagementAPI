using Microsoft.Extensions.Primitives;
using Serilog;
using System.Text;

namespace Events.API.Infrastructure.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;
        private readonly IHttpContextAccessor _httpAccessor;
        public RequestResponseLoggingMiddleware(RequestDelegate next, IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
            _next = next;
            _logger = new LoggerConfiguration()
          .MinimumLevel.Information()
          .WriteTo.File(@"..\RequestResponses\log.txt", rollingInterval: RollingInterval.Day)
          .CreateLogger();
        }

        public async Task Invoke(HttpContext context)
        {
            Stream originalBody = context.Response.Body;
            string responseBody = "No response body";
            string JWTtoken = String.Empty;
            try
            {
                if (_httpAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token))
                    JWTtoken = token[0];
                await LogRequest(context, JWTtoken);
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;

                    await _next(context);

                    memStream.Position = 0;
                    responseBody = new StreamReader(memStream).ReadToEnd();

                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                }

            }
            finally
            {
                context.Response.Body = originalBody;
                LogResponse(context.Response, responseBody);
            }
        }

        async Task LogRequest(HttpContext context, string JWTtoken)
        {
            HttpRequest request = context.Request;

            var text =
                $"{Environment.NewLine}-------------------------------------------------{Environment.NewLine}" +
                $"JWTtoken = {JWTtoken}{Environment.NewLine}" +
                $"IP = {request.HttpContext.Connection.RemoteIpAddress}{Environment.NewLine}" +
                $"Time = {DateTime.Now}{Environment.NewLine}" +
                $"Address = {request.Scheme}{Environment.NewLine}" +
                $"Path = {request.Path}{Environment.NewLine}" +
                $"IsSecured = {request.IsHttps}{Environment.NewLine}" +
                $"RequestBody = {await ReadRequestBody(request)}{Environment.NewLine}";

            _logger.Information(text);
        }

        void LogResponse(HttpResponse response, string body)
        {
            var text =
                $"-RESPONSE:{Environment.NewLine}" +
                $"Time = {DateTime.Now}{Environment.NewLine}" +
                $"ResponseBody = \n{body.Replace(',', '\n')}{Environment.NewLine}{Environment.NewLine}";

            _logger.Information(text);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();
            var buffer = new byte[request.ContentLength ?? 0];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Position = 0;
            return bodyAsText;
        }
    }
}
