using Domain;
using FluentValidation;

namespace Application.Features.Equipments.Commands.Validators
{
    public class UpdateEquipmentValidator : AbstractValidator<Equipment>
    {
        public UpdateEquipmentValidator()
        {
            RuleFor(x => x.EquipmentModelId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}