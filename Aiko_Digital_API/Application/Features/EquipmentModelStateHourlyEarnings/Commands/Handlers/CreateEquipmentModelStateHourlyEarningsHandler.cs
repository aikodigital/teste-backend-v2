using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentModelStateHourlyEarnings.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentModelStateHourlyEarnings.Commands.Handlers
{
    public class CreateEquipmentModelStateHourlyEarningsHandler 
        : IRequestHandler<CreateEquipmentModelStateHourlyEarningsCommand, 
            EquipmentModelStateHourlyEarningDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEquipmentModelStateHourlyEarningsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EquipmentModelStateHourlyEarningDto> 
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
                request.EquipmentStateId);

            var equipmentModelStateHourlyEarningsCheck =
                await _unitOfWork.Repository<EquipmentModelStateHourlyEarning>().GetEntityWithSpecAsync(specCheck);

            if (equipmentModelStateHourlyEarningsCheck != null)
                throw new WebException("Equipment Model State hourly Earnings exists in database, " +
                                       "for this Equipment Model and Equipment State! Try Update",
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

            return _mapper.Map<EquipmentModelStateHourlyEarning,
                EquipmentModelStateHourlyEarningDto>(equipmentModelStateHourlyEarnings);
        }
    }
}