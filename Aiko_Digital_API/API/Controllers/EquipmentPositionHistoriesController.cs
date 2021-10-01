using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.EquipmentPositionHistories.Commands.RequestModels;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentPositionHistoriesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<EquipmentPositionHistory>> 
            CreateEquipmentPositionHistory(CreateEquipmentPositionHistoriesCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<IReadOnlyList<EquipmentPositionHistory>> ListAllEquipmentPositionHistories()
        {
            return await Mediator.Send(new ListAllEquipmentPositionHistoriesQuery());
        }

        [HttpGet("{equipmentId}")]
        public async Task<IReadOnlyList<EquipmentPositionHistory>>
            GetEquipmentPositionHistoriesByEquipmentId(Guid equipmentId)
        {
            return await Mediator.Send(new GetEquipmentPositionHistoriesByEquipmentIdQuery 
                {EquipmentId = equipmentId});
        }
        
        [HttpPut("{equipmentId}/{date}")]
        public async Task<ActionResult<EquipmentPositionHistory>> 
            UpdateEquipmentPositionHistories(Guid equipmentId, DateTime date, 
                UpdateEquipmentPositionHistoriesCommand command)
        {
            command.EquipmentId = equipmentId;
            command.Date = date;
            return await Mediator.Send(command);
        }

        [HttpDelete("{equipmentId}/{date}")]
        public async Task<ActionResult<EquipmentPositionHistory>> 
            DeleteEquipmentPositionHistories(Guid equipmentId, DateTime date)
        {
            return await Mediator.Send(new DeleteEquipmentPositionHistoriesCommand 
                {EquipmentId =  equipmentId, Date = date});
        }
    }
}