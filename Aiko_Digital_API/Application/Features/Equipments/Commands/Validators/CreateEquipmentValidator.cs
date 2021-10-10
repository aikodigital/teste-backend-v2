using Application.Features.Equipments.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.Equipments.Commands.Validators
{
    public class CreateEquipmentValidator : AbstractValidator<CreateEquipmentCommand>
    {
        public CreateEquipmentValidator()
        {
            RuleFor(x => x.EquipmentModelId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}