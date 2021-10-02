using Application.Features.EquipmentStateHistories.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentStateHistories.Commands.Validator
{
    public class UpdateEquipmentStateHistoryValidator : AbstractValidator<UpdateEquipmentStateHistoryCommand>
    {
        public UpdateEquipmentStateHistoryValidator()
        {
            RuleFor(x => x.EquipmentStateId).NotEmpty();
        }
    }
}