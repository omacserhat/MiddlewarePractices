using Microsoft.AspNetCore.Builder;

namespace MiddlewarePractices.Middlewares
{
    public static class HelloMiddlewareExtensionBase
    {
        public static IApplicationBuilder UseHello(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloMiddleware>();
        }
    }
}