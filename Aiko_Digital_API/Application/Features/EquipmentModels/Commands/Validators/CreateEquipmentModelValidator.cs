using Application.Features.EquipmentModels.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentModels.Commands.Validators
{
    public class CreateEquipmentModelValidator : AbstractValidator<CreateEquipmentModelCommand>
    {
        public CreateEquipmentModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}