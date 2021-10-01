using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Commands.RequestModels
{
    public class DeleteEquipmentModelStateHourlyEarningsCommand 
        : IRequest<EquipmentModelStateHourlyEarning>
    {
        public Guid EquipmentModelId { get; set; }
        public Guid EquipmentStateId { get; set; }
    }
}