using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Equipments.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.Handlers
{
    public class ListAllEquipmentsHandler : IRequestHandler<ListAllEquipmentsQuery, IReadOnlyList<EquipmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListAllEquipmentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentDto>> Handle(ListAllEquipmentsQuery request, 
            CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            
            var equipments = await _unitOfWork.Repository<Equipment>()
                .ListAllWithSpecAsync(spec);
            
            return _mapper.Map<IReadOnlyList<Equipment>, IReadOnlyList<EquipmentDto>>(equipments);
        }
    }
}