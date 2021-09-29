using Domain;
using MediatR;

namespace Application.Features.EquipmentModels.Commands.RequestModels
{
    public class CreateEquipmentModelCommand : IRequest<EquipmentModel>
    {
        public string Name { get; set; }
    }
}