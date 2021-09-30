using Application.Features.EquipmentStates.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentStates.Commands.Validators
{
    public class UpdateEquipmentStateValidator : AbstractValidator<UpdateEquipmentStateCommand>
    {
        public UpdateEquipmentStateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
        }
    }
}