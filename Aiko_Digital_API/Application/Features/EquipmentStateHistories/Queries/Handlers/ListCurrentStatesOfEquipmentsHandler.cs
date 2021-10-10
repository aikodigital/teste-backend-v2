using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentStateHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.Handlers
{
    public class ListCurrentStatesOfEquipmentsHandler : 
        IRequestHandler<ListCurrentStatesOfEquipmentsQuery, 
            IReadOnlyList<EquipmentStateHistoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListCurrentStatesOfEquipmentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<EquipmentStateHistoryDto>> 
            Handle(ListCurrentStatesOfEquipmentsQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            var equipments = await _unitOfWork.Repository<Equipment>()
                .ListAllWithSpecAsync(spec);

            var equipmentStateHistory = new List<EquipmentStateHistory>();

            foreach (var equipment in equipments)
            {
                var specEquipmentStateHistory = new EquipmentStateHistorySpecification(equipment.Id,true);
                var currentStateEquipment = await _unitOfWork.Repository<EquipmentStateHistory>()
                    .GetLastEntityWithSpecAsync(specEquipmentStateHistory);
                equipmentStateHistory.Add(currentStateEquipment);
            }

            return _mapper.Map<IReadOnlyList<EquipmentStateHistory>, 
                IReadOnlyList<EquipmentStateHistoryDto>>(equipmentStateHistory);
        }
    }
}