using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.Handlers
{
    public class ListCurrentPositionsOfEquipmentsHandler : 
        IRequestHandler<ListCurrentPositionsOfEquipmentsQuery, 
            IReadOnlyList<EquipmentPositionHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListCurrentPositionsOfEquipmentsHandler(IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentPositionHistoryDto>> 
            Handle(ListCurrentPositionsOfEquipmentsQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            var equipments = await _unitOfWork.Repository<Equipment>()
                .ListAllWithSpecAsync(spec);

            var equipmentsPositionsHistories = new List<EquipmentPositionHistory>();

            foreach (var equipment in equipments)
            {
                var specEquipmentPositionHistory = new EquipmentPositionHistorySpecification(equipment.Id);
                var equipmentPositionHistory = await _unitOfWork.Repository<EquipmentPositionHistory>()
                    .GetLastEntityWithSpecAsync(specEquipmentPositionHistory);
                equipmentsPositionsHistories.Add(equipmentPositionHistory);
            }

            return _mapper.Map<IReadOnlyList<EquipmentPositionHistory>,
                IReadOnlyList<EquipmentPositionHistoryDto>>(equipmentsPositionsHistories);
        }
    }
}