using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Commands.RequestModels
{
    public class DeleteEquipmentModelStateHourlyEarningsCommand 
        : IRequest<EquipmentModelStateHourlyEarningDto>
    {
        public Guid EquipmentModelId { get; set; }
        public Guid EquipmentStateId { get; set; }
    }
}