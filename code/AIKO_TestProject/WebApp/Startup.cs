using AIKO_TestProject.Context;
using AIKO_TestProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
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
            services.AddRazorPages();
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentModelContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentStateContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentStateHistoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentPositionHistoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentModelStateHourlyEarningsContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentPositionLastHistoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentStateLastHistoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
