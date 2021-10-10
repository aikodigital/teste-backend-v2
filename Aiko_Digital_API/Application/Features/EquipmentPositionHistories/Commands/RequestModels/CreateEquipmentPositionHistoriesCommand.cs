using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Commands.RequestModels
{
    public class CreateEquipmentPositionHistoriesCommand : IRequest<EquipmentPositionHistoryDto>
    {
        public Guid EquipmentId { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        
    }
}