using Application.Features.EquipmentPositionHistories.Commands.RequestModels;
using FluentValidation;

namespace Application.Features.EquipmentPositionHistories.Commands.Validators
{
    public class CreateEquipmentPositionHistoriesValidator : 
        AbstractValidator<CreateEquipmentPositionHistoriesCommand>
    {
        public CreateEquipmentPositionHistoriesValidator()
        {
            RuleFor(x => x.EquipmentId).NotEmpty();
            RuleFor(x => x.Lat).NotEmpty();
            RuleFor(x => x.Lon).NotEmpty();
        }
    }
}