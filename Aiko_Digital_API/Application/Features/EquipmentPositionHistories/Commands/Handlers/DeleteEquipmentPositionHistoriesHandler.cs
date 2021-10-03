using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentPositionHistories.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Commands.Handlers
{
    public class DeleteEquipmentPositionHistoriesHandler : 
        IRequestHandler<DeleteEquipmentPositionHistoriesCommand, 
            EquipmentPositionHistoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEquipmentPositionHistoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<EquipmentPositionHistoryDto> Handle(DeleteEquipmentPositionHistoriesCommand request, 
            CancellationToken cancellationToken)
        {
            var specEquipment = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(specEquipment);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentPositionHistorySpecification(request.EquipmentId, request.Date);
            
            var equipmentPositionHistory = await _unitOfWork.Repository<EquipmentPositionHistory>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipmentPositionHistory == null)
                throw new WebException("Equipment Position History not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            _unitOfWork.Repository<EquipmentPositionHistory>().Delete(equipmentPositionHistory);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail to delete a Equipment Position History",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return _mapper.Map<EquipmentPositionHistory,
                EquipmentPositionHistoryDto>(equipmentPositionHistory);
        }
    }
}