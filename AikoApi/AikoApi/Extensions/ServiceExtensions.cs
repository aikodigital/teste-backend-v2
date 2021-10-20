using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace AikoApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurePsqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var sConn = configuration["Connection:AikoDb"];
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(sConn));
        }
        
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}