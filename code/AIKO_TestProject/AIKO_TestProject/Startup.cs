using AIKO_TestProject.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIKO_TestProject
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AIKO_TestProject", Version = "v1" });
            });

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentStateContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentModelContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentStateHistoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<EquipmentPositionHistoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<EquipmentModelStateHourlyEarningsContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
            services.AddEntityFrameworkNpgsql()
        .AddDbContext<EquipmentStateLastHistoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("AIKODB")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AIKO_TestProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
