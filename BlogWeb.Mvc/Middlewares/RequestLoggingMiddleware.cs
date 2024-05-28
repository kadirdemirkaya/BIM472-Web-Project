using System.Text;

namespace BlogWeb.Mvc.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath;

        public RequestLoggingMiddleware(RequestDelegate next, string logFilePath)
        {
            _next = next;
            _logFilePath = logFilePath;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestBodyText = await ReadRequestBody(context.Request);
            var logMessage = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] Incoming request: {context.Request.Method} {context.Request.Path}, Body: {requestBodyText}, Remote IP: {context.Connection.RemoteIpAddress}{Environment.NewLine}";

            await File.AppendAllTextAsync(_logFilePath, logMessage, Encoding.UTF8);

            await _next(context);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            using (var reader = new StreamReader(request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                request.Body.Position = 0;
                return body;
            }
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder, string logFilePath)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>(logFilePath);
        }
    }
}
