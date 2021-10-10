using Application.Features.EquipmentPositionHistories.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentPositionHistories.Commands.Validators
{
    public class UpdateEquipmentPositionHistoriesValidator : 
        AbstractValidator<UpdateEquipmentPositionHistoriesCommand>
    {
        public UpdateEquipmentPositionHistoriesValidator()
        {
            RuleFor(x => x.Lat).NotEmpty();
            RuleFor(x => x.Lon).NotEmpty();
        }
    }
}