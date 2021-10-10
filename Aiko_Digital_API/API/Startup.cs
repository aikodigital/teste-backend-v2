using API.Extensions;
using API.Middleware;
using Application.Features.Equipments.Queries.RequestModels;
using Application.Helpers;
using FluentValidation.AspNetCore;
using MediatR;
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
using Persistence;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostGreSQL"));
            });
            ConfigureServices(services);
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostGreSQL"));
            });
            ConfigureServices(services);
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddControllers()
                .AddFluentValidation(f =>
                {
                    f.RegisterValidatorsFromAssemblyContaining<ListAllEquipmentsQuery>();
                    f.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5003")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });    
            
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddApplicationServices();
            services.AddMediatR(typeof(ListAllEquipmentsQuery).Assembly);
            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}