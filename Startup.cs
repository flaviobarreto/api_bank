using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_bank.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace api_bank
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            app.UseSwagger();
                app.UseSwaggerUI();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();     // add this line
                endpoints.MapFallbackToFile("index.html");

            });
        }
    }
}
