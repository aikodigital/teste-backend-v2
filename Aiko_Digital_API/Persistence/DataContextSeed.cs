using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public class DataContextSeed
    {
        public DataContextSeed()
        {
        }

        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex, ex.Message);
            }
        }
    }
}