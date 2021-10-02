using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Equipments.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.Handlers
{
    public class GetEquipmentByIdHandler : IRequestHandler<GetEquipmentByIdQuery, Equipment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Equipment> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);
            
            return equipment;
        }
    }
}