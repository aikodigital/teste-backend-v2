using Application.Features.EquipmentModelStateHourlyEarnings.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Commands.Validators
{
    public class CreateEquipmentModelStateHourlyEarningsValidator 
        : AbstractValidator<CreateEquipmentModelStateHourlyEarningsCommand>
    {
        public CreateEquipmentModelStateHourlyEarningsValidator()
        {
            RuleFor(x => x.EquipmentModelId).NotEmpty();
            RuleFor(x => x.EquipmentStateId).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
        }
    }
}