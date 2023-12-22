using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ResStateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResStateAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                // Configurazione specifica per l'ambiente di sviluppo
                services.AddDbContext<RealEstateContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RealStateConnectionString")));
            }
            else if (HostingEnvironment.IsStaging())
            {
                // Configurazione specifica per l'ambiente di staging
                services.AddDbContext<RealEstateContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RealStateConnectionStringStaging")));
            }
            else
            {
                // Configurazione predefinita per altri ambienti
                services.AddDbContext<RealEstateContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RealStateConnectionString")));
            }

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
