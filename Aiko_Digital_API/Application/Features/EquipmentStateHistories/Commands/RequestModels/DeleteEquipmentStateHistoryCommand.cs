using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Commands.RequestModels
{
    public class DeleteEquipmentStateHistoryCommand : IRequest<EquipmentStateHistoryDto>
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
    }
}