using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AikoApi.Extensions
{
    public static class ServiceExtensions
    {
        //Todo: testar conexao
        public static void ConfigurePsqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var sConn = configuration["Connection:AikoDb"];
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(sConn));
        }
    }
}