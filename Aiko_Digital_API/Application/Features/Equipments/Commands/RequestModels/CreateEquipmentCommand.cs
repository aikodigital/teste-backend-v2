using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Commands.RequestModels
{
    public class CreateEquipmentCommand : IRequest<EquipmentDto>
    {
        public Guid EquipmentModelId { get; set; }
        public string Name { get; set; }
    }
}