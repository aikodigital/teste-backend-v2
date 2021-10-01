using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Commands.RequestModels
{
    public class CreateEquipmentPositionHistoriesCommand : IRequest<EquipmentPositionHistory>
    {
        public Guid EquipmentId { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        
    }
}