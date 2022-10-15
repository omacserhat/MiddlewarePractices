﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MiddlewarePractices.Middlewares
{
    public class HelloMiddleware
    {
        private readonly RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)
        {
              _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Hello World!");
            await _next.Invoke(context);
            Console.WriteLine("Bye World!");
        }
        public static class HelloMiddlewareExtension
        {
           public static IApplicationBuilder UseHello(IApplicationBuilder builder)
            {
                return builder.UseMiddleware<HelloMiddleware>();
            }
        }
    }
}
