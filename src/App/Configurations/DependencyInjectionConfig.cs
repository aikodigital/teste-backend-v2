using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;

using Microsoft.Extensions.DependencyInjection;

namespace App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            /* Repositories */
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IPositionHistoryRepository, PositionHistoryRepository>();
            services.AddScoped<IStateHistoryRepository, StateHistoryRepository>();
            services.AddScoped<IModelStateHourlyEarningsRepository, ModelStateHourlyEarningsRepository>();
            
            /* Services */
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IPositionHistoryService, PositionHistoryService>();
            services.AddScoped<IStateHistoryService, StateHistoryService>();
            services.AddScoped<IModelStateHourlyEarningService, ModelStateHourlyEarningService>();
            
            return services;
        }
    }
}