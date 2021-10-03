using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentStateHistories.Commands.RequestModels;
using Application.Features.EquipmentStateHistories.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentStateHistoriesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<EquipmentStateHistoryDto>> 
            CreateEquipmentStateHistory(CreateEquipmentStateHistoryCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<IReadOnlyList<EquipmentStateHistoryDto>> ListAllEquipmentStateHistories()
        {
            return await Mediator.Send(new ListAllEquipmentStateHistoriesQuery());
        }

        [HttpGet("currentStatesOfEquipments")]
        public async Task<IReadOnlyList<EquipmentStateHistoryDto>> ListCurrentStatesOfEquipments()
        {
            return await Mediator.Send(new ListCurrentStatesOfEquipmentsQuery());
        }

        [HttpGet("{equipmentId}")]
        public async Task<IReadOnlyList<EquipmentStateHistoryDto>> 
            GetEquipmentStateHistoriesByEquipmentId(Guid equipmentId)
        {
            return await Mediator.Send(new GetEquipmentStateHistoriesByEquipmentIdQuery 
                {EquipmentId = equipmentId});
        }

        [HttpPut("{equipmentId}/{date}")]
        public async Task<ActionResult<EquipmentStateHistoryDto>> 
            UpdateEquipmentStateHistory(Guid equipmentId, DateTime date, 
                UpdateEquipmentStateHistoryCommand command)
        {
            command.EquipmentId = equipmentId;
            command.Date = date;
            return await Mediator.Send(command);
        }

        [HttpDelete("{equipmentId}/{date}")]
        public async Task<ActionResult<EquipmentStateHistoryDto>> 
            DeleteEquipmentStateHistory(Guid equipmentId, DateTime date)
        {
            return await Mediator.Send(new DeleteEquipmentStateHistoryCommand
            {
                EquipmentId = equipmentId, Date = date
            });
        }
    }
}