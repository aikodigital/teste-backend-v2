using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Commands.RequestModels
{
    public class UpdateEquipmentCommand : IRequest<EquipmentDto>
    {
        public Guid EquipmentId { get; set; }
        public Guid EquipmentModelId { get; set; }
        public string Name { get; set; }
    }
}