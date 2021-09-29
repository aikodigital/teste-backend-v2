using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Equipments.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Equipments.Queries.Handlers
{
    public class ListAllEquipmentsHandler : IRequestHandler<ListAllEquipmentsQuery, IReadOnlyList<Equipment>>
    {
        private readonly IGenericRepository<Equipment> _genericRepository;

        public ListAllEquipmentsHandler(IGenericRepository<Equipment> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<IReadOnlyList<Equipment>> Handle(ListAllEquipmentsQuery request, CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            
            return await _genericRepository.ListAllWithSpecAsync(spec);
        }
    }
}