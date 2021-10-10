using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Commands.RequestModels
{
    public class CreateEquipmentStateCommand : IRequest<EquipmentState>
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}