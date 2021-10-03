using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Equipments.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Equipments.Queries.Handlers
{
    public class GetEquipmentProductivityPercentageHandler : 
        IRequestHandler<GetEquipmentProductivityPercentageQuery, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentProductivityPercentageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<string> Handle(GetEquipmentProductivityPercentageQuery request, 
            CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var specState = new EquipmentStateSpecification("Operando");
            var equipmentState = await _unitOfWork.Repository<EquipmentState>()
                .GetEntityWithSpecAsync(specState);
            
            if (equipmentState == null)
                throw new WebException("Equipment state not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var specEquipmentStateHistoryOperation = new EquipmentStateHistorySpecification
                (request.EquipmentId, request.Date, equipmentState.Id);

            double equipmentStateHistoryOperation = await _unitOfWork.Repository<EquipmentStateHistory>()
                .CountAsync(specEquipmentStateHistoryOperation);

            double equipmentProductivity = equipmentStateHistoryOperation / 24;

            var equipmentProductivityPercentage = equipmentProductivity.ToString("P",
                CultureInfo.CreateSpecificCulture("hr-HR"));

            return equipmentProductivityPercentage;
        }
    }
}