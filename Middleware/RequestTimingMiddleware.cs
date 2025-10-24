namespace LibraryApiDemo.Middleware;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimingMiddleware> _logger;

    public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        await _next(context);
        sw.Stop();
        var ms = sw.ElapsedMilliseconds;
        context.Response.Headers["X-Request-Duration-ms"] = ms.ToString();
        _logger.LogInformation("Request {method} {path} took {elapsed} ms", context.Request.Method, context.Request.Path, ms);
    }
}
public static class RequestTimingExtensions
{
    public static IApplicationBuilder UseRequestTiming(this IApplicationBuilder app)
        => app.UseMiddleware<RequestTimingMiddleware>();
}
