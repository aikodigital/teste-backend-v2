using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentModelStateHourlyEarnings.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Commands.Handlers
{
    public class CreateEquipmentModelStateHourlyEarningsHandler 
        : IRequestHandler<CreateEquipmentModelStateHourlyEarningsCommand, 
            EquipmentModelStateHourlyEarning>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEquipmentModelStateHourlyEarningsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EquipmentModelStateHourlyEarning> 
            Handle(CreateEquipmentModelStateHourlyEarningsCommand request, 
                CancellationToken cancellationToken)
        {
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetByIdAsync(request.EquipmentStateId);
            
            if (equipmentState == null)
                throw new WebException("Equipment state not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var specCheck = new EquipmentModelStateHourlyEarningsSpecification(request.EquipmentModelId,
                request.EquipmentStateId, request.Value);

            var equipmentModelStateHourlyEarningsCheck =
                await _unitOfWork.Repository<EquipmentModelStateHourlyEarning>().GetEntityWithSpec(specCheck);

            if (equipmentModelStateHourlyEarningsCheck != null)
                throw new WebException("Equipment Model State hourly Earnings exists in database!",
                    (WebExceptionStatus) HttpStatusCode.Conflict);
            
            var equipmentModelStateHourlyEarnings = new EquipmentModelStateHourlyEarning
            {
                EquipmentModel = equipmentModel,
                EquipmentState = equipmentState,
                Value = request.Value
            };
            
            _unitOfWork.Repository<EquipmentModelStateHourlyEarning>()
                .AddAsync(equipmentModelStateHourlyEarnings);
            
            var result = await _unitOfWork.Complete();

            if(result <= 0)
                throw new WebException("Fail to create Equipment Model State hourly Earnings",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return equipmentModelStateHourlyEarnings;

        }
    }
}