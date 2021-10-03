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
    public class DeleteEquipmentModelStateHourlyEarningsHandler 
        : IRequestHandler<DeleteEquipmentModelStateHourlyEarningsCommand, 
            EquipmentModelStateHourlyEarningDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEquipmentModelStateHourlyEarningsHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<EquipmentModelStateHourlyEarningDto> 
            Handle(DeleteEquipmentModelStateHourlyEarningsCommand request, 
                CancellationToken cancellationToken)
        {
            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetByIdAsync(request.EquipmentStateId);
            
            if (equipmentState == null)
                throw new WebException("Equipment state not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentModelStateHourlyEarningsSpecification(request.EquipmentModelId,
                request.EquipmentStateId);
            
            var equipmentModelStateHourlyEarnings =
                await _unitOfWork.Repository<EquipmentModelStateHourlyEarning>()
                    .GetEntityWithSpecAsync(spec);
            
            if (equipmentModelStateHourlyEarnings == null)
                throw new WebException("Equipment Model State hourly Earnings not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            _unitOfWork.Repository<EquipmentModelStateHourlyEarning>()
                .Delete(equipmentModelStateHourlyEarnings);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail to delete a Equipment Model State hourly Earnings",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return _mapper.Map<EquipmentModelStateHourlyEarning,
                EquipmentModelStateHourlyEarningDto>(equipmentModelStateHourlyEarnings);
        }
    }
}