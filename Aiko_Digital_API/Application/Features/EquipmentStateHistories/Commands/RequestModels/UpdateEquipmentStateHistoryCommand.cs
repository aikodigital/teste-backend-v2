using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Commands.RequestModels
{
    public class UpdateEquipmentStateHistoryCommand : IRequest<EquipmentStateHistoryDto>
    {
        public Guid EquipmentId { get; set; }
        public Guid EquipmentStateId { get; set; }
        public DateTime Date { get; set; }
        
    }
}