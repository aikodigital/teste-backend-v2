using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Equipments.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.Handlers
{
    public class ListAllEquipmentsHandler : IRequestHandler<ListAllEquipmentsQuery, IReadOnlyList<Equipment>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListAllEquipmentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<Equipment>> Handle(ListAllEquipmentsQuery request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            
            return await _unitOfWork.Repository<Equipment>().ListAllWithSpecAsync(spec);
        }
    }
}