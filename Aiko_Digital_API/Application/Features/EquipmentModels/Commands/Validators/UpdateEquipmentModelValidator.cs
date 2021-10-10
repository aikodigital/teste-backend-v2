using Application.Features.EquipmentModels.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentModels.Commands.Validators
{
    public class UpdateEquipmentModelValidator : AbstractValidator<UpdateEquipmentModelCommand>
    {
        public UpdateEquipmentModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}