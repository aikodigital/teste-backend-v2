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
    public class DeleteEquipmentHandler : IRequestHandler<DeleteEquipmentCommand, Equipment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEquipmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Equipment> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpec(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            _unitOfWork.Repository<Equipment>().Delete(equipment);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
                throw new WebException("Fail to delete a Equipment",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);

            return equipment;
        }
    }
}