using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentStates.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStates.Queries.Handlers
{
    public class ListAllEquipmentStatesHandler : IRequestHandler<ListAllEquipmentStatesQuery, IReadOnlyList<EquipmentState>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListAllEquipmentStatesHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentState>> Handle(ListAllEquipmentStatesQuery request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentStateSpecification(); 
            return await _unitOfWork.Repository<EquipmentState>().ListAllWithSpecAsync(spec); 
        }
    }
}