using System;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Commands.RequestModels
{
    public class DeleteEquipmentCommand : IRequest<Equipment>
    {
        public Guid EquipmentId { get; set; }
    }
}