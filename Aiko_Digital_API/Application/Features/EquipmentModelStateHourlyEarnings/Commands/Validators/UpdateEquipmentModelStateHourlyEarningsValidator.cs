using Domain;
using FluentValidation;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Commands.Validators
{
    public class UpdateEquipmentModelStateHourlyEarningsValidator 
        : AbstractValidator<EquipmentModelStateHourlyEarning>
    {
        public UpdateEquipmentModelStateHourlyEarningsValidator()
        {
            RuleFor(x => x.EquipmentModelId).NotEmpty();
            RuleFor(x => x.EquipmentStateId).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
        }    
    }
}