using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Equipments.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Commands.Handlers
{
    public class UpdateEquipmentHandler : IRequestHandler<UpdateEquipmentCommand, Equipment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEquipmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Equipment> Handle(UpdateEquipmentCommand request, 
            CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>().GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var equipmentModel = await _unitOfWork.Repository<EquipmentModel>()
                .GetByIdAsync(request.EquipmentModelId);
            
            if (equipmentModel == null)
                throw new WebException("Equipment Model not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            var specCheckName = new EquipmentSpecification(request.EquipmentId,request.Name);
            var equipmentCheckName = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(specCheckName);
            
            if (equipmentCheckName != null)
                throw new WebException("Fail to update Equipment " +
                                       "because the equipment exists in database!",
                    (WebExceptionStatus) HttpStatusCode.Conflict);
            
            equipment.Name = request.Name;
            equipment.EquipmentModel = equipmentModel;
            
            _unitOfWork.Repository<Equipment>().Update(equipment);
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail in update Equipment",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);
            
            return equipment;
        }
    }
}