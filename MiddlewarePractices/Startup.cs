using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MiddlewarePractices.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePractices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MiddlewarePractices", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiddlewarePractices v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            //app.Run()
            //Run'da 1. çalışır 2.sinde Kısa devre olur.
            //app.Run(async context => Console.WriteLine("Middleware 1."));
            //app.Run(async context => Console.WriteLine("Middleware 2."));


            //app.Use
            //1 başladı,2 başladı,3 başladı -- 3 sonlandırıldı,2 sonlandırıldı, 1 sonlandırıld şeklibde çalışır.


            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Middleware 1 başladı.");

            //    await next.Invoke();

            //    Console.WriteLine("Middleware 1 sonlandırılıyor.");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Middleware 2 başladı.");

            //    await next.Invoke();

            //    Console.WriteLine("Middleware 2 sonlandırılıyor.");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Middleware 3 başladı.");

            //    await next.Invoke();

            //    Console.WriteLine("Middleware 3 sonlandırılıyor.");
            //});


            //ilk önce programı çalıştırdığımızda use middleware tetiklendi yazar.
            //test'e bir istek geldiğinde response olarak (test middleware tetiklendi) yazar.

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Use Middleware tetiklendi");

            //    await next.Invoke();
            //});


            //app.Map("/test", internalApp =>
            // internalApp.Run(async context =>
            //{
            //    Console.WriteLine("/test middleware tetiklendi.");
            //    await context.Response.WriteAsync("/test middleware tetiklendi.");
            //}));

            //Get isteği yapıldığında bu middleware tetiklenecek.
            //app.MapWhen(x => x.Request.Method == "GET", internalApp =>
            //{
            //    internalApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("MapWhen ile Middleware Tetiklendi.");
            //    });
            //});

            app.UseHello();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
