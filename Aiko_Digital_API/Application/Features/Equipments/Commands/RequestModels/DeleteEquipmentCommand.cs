using System;
using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Commands.RequestModels
{
    public class DeleteEquipmentCommand : IRequest<EquipmentDto>
    {
        public Guid EquipmentId { get; set; }
    }
}