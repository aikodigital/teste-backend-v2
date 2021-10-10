using Application.Features.EquipmentStates.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentStates.Commands.Validators
{
    public class CreateEquipmentStateValidator : AbstractValidator<CreateEquipmentStateCommand>
    {
        public CreateEquipmentStateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
        }
    }
}