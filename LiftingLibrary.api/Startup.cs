using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftingLibrary.data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LiftingLibrary.api
{
    public class Startup
    {
        private const string ALL_CORS = "all";
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Dev"));
            services.AddCors(options => options.AddPolicy(ALL_CORS, build => build.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()));
            
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseCors(ALL_CORS);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}