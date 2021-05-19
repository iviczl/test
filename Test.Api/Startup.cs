using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Data.Repositories;
using Test.Service;
using Test.Service.Services;

namespace Test.Api
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
            services.AddScoped(c => new DataContext(AppContext.BaseDirectory + @"\json")); //Configuration.GetValue<string>("DataPath")
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IMeasurementPointRepository, MeasurementPointRepository>();
            services.AddScoped<IMeasurementService, MeasurementService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IMeasurementPointService, MeasurementPointService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.WithOrigins(Configuration["AllowedOrigins"].Split(",")).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
