using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)

    {
        
        // TODO1: Generate a short correlation ID
        var correlationId = Guid.NewGuid().ToString("N")[..8];

        // TODO2: Stamp header BEFORE calling next
        context.Response.Headers["X-Correlation-Id"] = correlationId;

        // TODO3: Start stopwatch
        var stopwatch = Stopwatch.StartNew();

        // TODO4: Log entry line (method, path, correlationId)
        _logger.LogInformation("Starting {Method} {Path} (CorrelationId={CorrelationId})",
            context.Request.Method,
            context.Request.Path,
            correlationId);

        // Pass control to next middleware
        await _next(context);

        // TODO5: Stop stopwatch
        stopwatch.Stop();

        // TODO6: Log exit line (status code, elapsed ms, correlationId)
        _logger.LogInformation("Completed {Method} {Path} with {StatusCode} in {Elapsed}ms (CorrelationId={CorrelationId})",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds,
            correlationId);
    }

}
