using Serilog;

namespace NlayeredAPI.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private static readonly Serilog.ILogger _logger = Log.ForContext<GlobalExceptionMiddleware>();
        public GlobalExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        // Global log middleware
        public async void InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
                _logger.Error($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}, Action'a girildi.");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        //Global exception middleware
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            _logger.Error($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}", ex);
            return Task.CompletedTask;
        }
    }
}
