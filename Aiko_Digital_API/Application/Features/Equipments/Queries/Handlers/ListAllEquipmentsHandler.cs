using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Equipments.Queries.RequestModels;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Equipments.Queries.Handlers
{
    public class ListAllEquipmentsHandler : IRequestHandler<ListAllEquipmentsQuery, IReadOnlyList<Equipment>>
    {
        private readonly DataContext _context;

        public ListAllEquipmentsHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Equipment>> Handle(ListAllEquipmentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Equipment.Include(x=>x.EquipmentModel).ToListAsync();
        }
    }
}