using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentStates.Queries.RequestModels;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Queries.Handlers
{
    public class GetEquipmentStateHandler : IRequestHandler<GetEquipmentStateByIdQuery,EquipmentState>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentStateHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentState> Handle(GetEquipmentStateByIdQuery request, CancellationToken cancellationToken)
        {
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetByIdAsync(request.EquipmentStateId);
            
            if (equipmentState == null)
                throw new WebException("Equipment state not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            return equipmentState;
        }
    }
}