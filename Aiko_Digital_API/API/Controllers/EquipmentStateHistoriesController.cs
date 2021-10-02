using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.EquipmentStateHistories.Commands.RequestModels;
using Application.Features.EquipmentStateHistories.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentStateHistoriesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<EquipmentStateHistory>> 
            CreateEquipmentStateHistory(CreateEquipmentStateHistoryCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<IReadOnlyList<EquipmentStateHistory>> ListAllEquipmentStateHistories()
        {
            return await Mediator.Send(new ListAllEquipmentStateHistoriesQuery());
        }

        [HttpGet("{equipmentId}")]
        public async Task<IReadOnlyList<EquipmentStateHistory>> 
            GetEquipmentStateHistoriesByEquipmentId(Guid equipmentId)
        {
            return await Mediator.Send(new GetEquipmentStateHistoriesByEquipmentIdQuery 
                {EquipmentId = equipmentId});
        }

        [HttpPut("{equipmentId}/{date}")]
        public async Task<ActionResult<EquipmentStateHistory>> 
            UpdateEquipmentStateHistory(Guid equipmentId, DateTime date, 
                UpdateEquipmentStateHistoryCommand command)
        {
            command.EquipmentId = equipmentId;
            command.Date = date;
            return await Mediator.Send(command);
        }

        [HttpDelete("{equipmentId}/{date}")]
        public async Task<ActionResult<EquipmentStateHistory>> 
            DeleteEquipmentStateHistory(Guid equipmentId, DateTime date)
        {
            return await Mediator.Send(new DeleteEquipmentStateHistoryCommand
            {
                EquipmentId = equipmentId, Date = date
            });
        }
    }
}