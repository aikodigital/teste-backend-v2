using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Commands.RequestModels
{
    public class CreateEquipmentStateHistoryCommand : IRequest<EquipmentStateHistoryDto>
    {
        public Guid EquipmentId { get; set; }
        public Guid EquipmentStateId { get; set; }
    }
}