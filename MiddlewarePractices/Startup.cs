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
            //Run'da 1. �al���r 2.sinde K�sa devre olur.
            //app.Run(async context => Console.WriteLine("Middleware 1."));
            //app.Run(async context => Console.WriteLine("Middleware 2."));


            //app.Use
            //1 ba�lad�,2 ba�lad�,3 ba�lad� -- 3 sonland�r�ld�,2 sonland�r�ld�, 1 sonland�r�ld �eklibde �al���r.


            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Middleware 1 ba�lad�.");

            //    await next.Invoke();

            //    Console.WriteLine("Middleware 1 sonland�r�l�yor.");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Middleware 2 ba�lad�.");

            //    await next.Invoke();

            //    Console.WriteLine("Middleware 2 sonland�r�l�yor.");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Middleware 3 ba�lad�.");

            //    await next.Invoke();

            //    Console.WriteLine("Middleware 3 sonland�r�l�yor.");
            //});


            //ilk �nce program� �al��t�rd���m�zda use middleware tetiklendi yazar.
            //test'e bir istek geldi�inde response olarak (test middleware tetiklendi) yazar.

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

            //Get iste�i yap�ld���nda bu middleware tetiklenecek.
            //app.MapWhen(x => x.Request.Method == "GET", internalApp =>
            //{
            //    internalApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("MapWhen ile Middleware Tetiklendi.");
            //    });
            //});


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
