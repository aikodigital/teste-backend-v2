using Application.Behaviours;
using Application.Features.services;
using Application.Interfaces.Services;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient<IEquipamentoService, EquipamentoService>();
            services.AddTransient<IModeloEquipamentoService, ModeloEquipamentoService>();
            services.AddTransient<IEstadoEquipamentoService, EstadoEquipamentoService>();
            services.AddTransient<IGanhosHoraEstadoService, GanhosHoraEstadoService>();
            services.AddTransient<IHistoricoEstadoEquipamentoService, HistoricoEstadoEquipamentoService>();
            services.AddTransient<IHistoricoPosicaoEquipamentoService, HistoricoPosicaoEquipamentoService>();
        }
    }
}
