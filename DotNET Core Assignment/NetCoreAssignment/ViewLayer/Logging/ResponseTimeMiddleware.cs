using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ViewLayer.Logging
{
    public class ResponseTimeMiddleware
    {
        // Handle to the next Middleware in the pipeline  
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ResponseTimeMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;
            if (path.Equals("/"))
            {
                path = "Home/Index";
            }
           
            // Start the Timer using Stopwatch  
            var watch = new Stopwatch();
            watch.Start();

            context.Response.OnStarting(() => {
                // Stop the timer information and calculate the time   
                watch.Stop();

                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;

                // Add the Response time information in the Response headers.   
                context.Response.Headers["Page-Response-Time-ms"] = responseTimeForCompleteRequest.ToString();

                // Log the Response time information in the File.   
                _logger.LogInformation($"({path}) Response time Captured : {responseTimeForCompleteRequest}");

                return Task.CompletedTask;
            });

            // Call the next delegate/middleware in the pipeline   
            return this._next(context);
        }
    }
}
