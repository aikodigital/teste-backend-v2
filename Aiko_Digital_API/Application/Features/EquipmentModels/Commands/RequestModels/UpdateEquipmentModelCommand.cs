using System;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModels.Commands.RequestModels
{
    public class UpdateEquipmentModelCommand : IRequest<EquipmentModel>
    {
        public Guid EquipmentModelId { get; set; }
        public string Name { get; set; }
    }
}