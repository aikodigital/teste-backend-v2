using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.EquipmentStateHistories.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.EquipmentStateHistories.Queries.Handlers
{
    public class ListCurrentStatesOfEquipmentsHandler : 
        IRequestHandler<ListCurrentStatesOfEquipmentsQuery, 
            IReadOnlyList<EquipmentStateHistory>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListCurrentStatesOfEquipmentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IReadOnlyList<EquipmentStateHistory>> 
            Handle(ListCurrentStatesOfEquipmentsQuery request, 
                CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification();
            var equipments = await _unitOfWork.Repository<Equipment>()
                .ListAllWithSpecAsync(spec);

            var equipmentStateHistory = new List<EquipmentStateHistory>();

            foreach (var equipment in equipments)
            {
                var specEquipmentStateHistory = new EquipmentStateHistorySpecification(equipment.Id);
                var currentStateEquipment = await _unitOfWork.Repository<EquipmentStateHistory>()
                    .GetLastEntityWithSpecAsync(specEquipmentStateHistory);
                equipmentStateHistory.Add(currentStateEquipment);
            }

            return equipmentStateHistory;
        }
    }
}