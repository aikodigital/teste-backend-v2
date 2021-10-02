using Application.Features.EquipmentStateHistories.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentStateHistories.Commands.Validator
{
    public class CreateEquipmentStateHistoryValidator : 
        AbstractValidator<CreateEquipmentStateHistoryCommand>
    {
        public CreateEquipmentStateHistoryValidator()
        {
            RuleFor(x => x.EquipmentId).NotEmpty();
            RuleFor(x => x.EquipmentStateId).NotEmpty();
        }    
    }
}