using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentStates.Commands.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Commands.Handlers
{
    public class CreateEquipmentStateHandler : IRequestHandler<CreateEquipmentStateCommand,
        EquipmentState>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEquipmentStateHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<EquipmentState> Handle(CreateEquipmentStateCommand request, 
            CancellationToken cancellationToken)
        {
            var spec = new EquipmentStateSpecification(request.Name, request.Color);
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipmentState != null)
                throw new WebException("Fail to create Equipment State " +
                                       "because the equipment state exists in database!",
                    (WebExceptionStatus) HttpStatusCode.Conflict);

            equipmentState = new EquipmentState
            {
                Name = request.Name,
                Color = request.Color
            };

            _unitOfWork.Repository<EquipmentState>().AddAsync(equipmentState);
            
            var result = await _unitOfWork.Complete();

            if(result <= 0)
                throw new WebException("Fail to create Equipment State",
                    (WebExceptionStatus) HttpStatusCode.InternalServerError);
            
            return equipmentState;
        }
    }
}