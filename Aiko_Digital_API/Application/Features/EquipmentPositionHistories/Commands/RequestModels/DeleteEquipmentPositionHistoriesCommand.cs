using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Commands.RequestModels
{
    public class DeleteEquipmentPositionHistoriesCommand : IRequest<EquipmentPositionHistoryDto>
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
    }
}