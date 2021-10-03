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
    public class GetEquipmentGainHandler : IRequestHandler<GetEquipmentGainQuery,float>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEquipmentGainHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<float> Handle(GetEquipmentGainQuery request, 
            CancellationToken cancellationToken)
        {
            var spec = new EquipmentSpecification(request.EquipmentId);
            var equipment = await _unitOfWork.Repository<Equipment>()
                .GetEntityWithSpecAsync(spec);
            
            if (equipment == null)
                throw new WebException("Equipment not found!",
                    (WebExceptionStatus) HttpStatusCode.NotFound);

            var equipmentStates = await _unitOfWork.Repository<EquipmentState>()
                .GetAllAsync();
            
            float operation = 0;
            float maintenance = 0;
            float stop = 0;
            
            foreach (var equipmentState in equipmentStates)
            {
                var specEquipmentModelStateHourlyEarning = new EquipmentModelStateHourlyEarningsSpecification
                (equipment.EquipmentModelId, equipmentState.Id);

                var equipmentModelStateHourlyEarning = await _unitOfWork.Repository<EquipmentModelStateHourlyEarning>()
                    .GetEntityWithSpecAsync(specEquipmentModelStateHourlyEarning);

                switch (equipmentState.Name)
                {
                    case "Operando": 
                        var specEquipmentStateHistoryOperation = new EquipmentStateHistorySpecification
                            (request.EquipmentId, request.Date, equipmentState.Name);

                        var equipmentStateHistoryOperation = await _unitOfWork.Repository<EquipmentStateHistory>()
                            .CountAsync(specEquipmentStateHistoryOperation);
                        
                        operation = equipmentModelStateHourlyEarning.Value * equipmentStateHistoryOperation;
                        
                        break;
                    
                    case "Manutenção":
                        var specEquipmentStateHistoryMaintenance = new EquipmentStateHistorySpecification
                            (request.EquipmentId, request.Date, equipmentState.Name);

                        var equipmentStateHistoryMaintenance = await _unitOfWork.Repository<EquipmentStateHistory>()
                            .CountAsync(specEquipmentStateHistoryMaintenance);

                        maintenance = equipmentModelStateHourlyEarning.Value * equipmentStateHistoryMaintenance;
                            
                        break;
                    
                    case "Parado":
                        var specEquipmentStateHistoryStop = new EquipmentStateHistorySpecification
                            (request.EquipmentId, request.Date, equipmentState.Name);

                        var equipmentStateHistoryStop = await _unitOfWork.Repository<EquipmentStateHistory>()
                            .CountAsync(specEquipmentStateHistoryStop);

                        stop = equipmentModelStateHourlyEarning.Value * equipmentStateHistoryStop;
                        
                        break;
                }
            }
            var equipmentGain = operation + maintenance + stop;

            return equipmentGain;
        }
    }
}