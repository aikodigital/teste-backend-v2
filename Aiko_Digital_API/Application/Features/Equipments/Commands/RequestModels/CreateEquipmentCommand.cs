using System;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Commands.RequestModels
{
    public class CreateEquipmentCommand : IRequest<Equipment>
    {
        public Guid EquipmentModelId { get; set; }
        public string Name { get; set; }
    }
}