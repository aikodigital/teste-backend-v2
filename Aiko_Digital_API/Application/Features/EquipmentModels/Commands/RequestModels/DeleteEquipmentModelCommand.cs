using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModels.Commands.RequestModels
{
    public class DeleteEquipmentModelCommand : IRequest<EquipmentModel>
    {
        public Guid EquipmentModelId { get; set; }
    }
}