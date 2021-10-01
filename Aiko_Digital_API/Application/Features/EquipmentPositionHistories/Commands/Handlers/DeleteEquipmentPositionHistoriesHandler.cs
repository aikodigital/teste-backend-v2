using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentPositionHistories.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Commands.Handlers
{
    public class DeleteEquipmentPositionHistoriesHandler : 
        IRequestHandler<DeleteEquipmentPositionHistoriesCommand, 
            EquipmentPositionHistory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEquipmentPositionHistoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentPositionHistory> Handle(DeleteEquipmentPositionHistoriesCommand request, 
            CancellationToken cancellationToken)
        {
            var specEquipment = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpec(specEquipment);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var spec = new EquipmentPositionHistorySpecification(request.EquipmentId, request.Date);
            
            var equipmentPositionHistory = await _unitOfWork.Repository<EquipmentPositionHistory>()
                .GetEntityWithSpec(spec);
            
            if (equipmentPositionHistory == null)
                throw new WebException("Equipment Position History not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            _unitOfWork.Repository<EquipmentPositionHistory>().Delete(equipmentPositionHistory);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail to delete a Equipment Position History",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return equipmentPositionHistory;
        }
    }
}