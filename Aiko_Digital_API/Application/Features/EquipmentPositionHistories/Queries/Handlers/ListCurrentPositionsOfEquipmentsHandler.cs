using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentPositionHistories.Queries.Handlers
{
    public class ListCurrentPositionsOfEquipmentsHandler : 
        IRequestHandler<ListCurrentPositionsOfEquipmentsQuery, 
            IReadOnlyList<EquipmentPositionHistory>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListCurrentPositionsOfEquipmentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentPositionHistory>> 
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

            return equipmentsPositionsHistories;
        }
    }
}