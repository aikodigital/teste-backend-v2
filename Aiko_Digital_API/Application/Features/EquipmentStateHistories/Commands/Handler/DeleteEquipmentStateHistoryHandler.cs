using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentStateHistories.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Commands.Handler
{
    public class DeleteEquipmentStateHistoryHandler : 
        IRequestHandler<DeleteEquipmentStateHistoryCommand, 
            EquipmentStateHistoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEquipmentStateHistoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<EquipmentStateHistoryDto> 
            Handle(DeleteEquipmentStateHistoryCommand request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var specEquipmentStateHistory = new EquipmentStateHistorySpecification
                (request.EquipmentId, request.Date);

            var equipmentStateHistory = await _unitOfWork.Repository<EquipmentStateHistory>()
                .GetEntityWithSpecAsync(specEquipmentStateHistory);
            
            if (equipmentStateHistory == null)
                throw new WebException("Equipment State History not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            _unitOfWork.Repository<EquipmentStateHistory>().Delete(equipmentStateHistory);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail to delete a Equipment State History",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return _mapper.Map<EquipmentStateHistory,EquipmentStateHistoryDto>
                (equipmentStateHistory);
        }
    }
}