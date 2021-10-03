using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.EquipmentPositionHistories.Commands.RequestModels;
using Application.Features.EquipmentPositionHistories.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentPositionHistoriesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<EquipmentPositionHistoryDto>> 
            CreateEquipmentPositionHistory(CreateEquipmentPositionHistoriesCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<IReadOnlyList<EquipmentPositionHistoryDto>> ListAllEquipmentPositionHistories()
        {
            return await Mediator.Send(new ListAllEquipmentPositionHistoriesQuery());
        }
        
        [HttpGet("currentPositionsOfEquipments")]
        public async Task<IReadOnlyList<EquipmentPositionHistoryDto>> ListCurrentPositionsOfEquipments()
        {
            return await Mediator.Send(new ListCurrentPositionsOfEquipmentsQuery());
        }

        [HttpGet("{equipmentId}")]
        public async Task<IReadOnlyList<EquipmentPositionHistoryDto>>
            GetEquipmentPositionHistoriesByEquipmentId(Guid equipmentId)
        {
            return await Mediator.Send(new GetEquipmentPositionHistoriesByEquipmentIdQuery 
                {EquipmentId = equipmentId});
        }
        
        [HttpPut("{equipmentId}/{date}")]
        public async Task<ActionResult<EquipmentPositionHistoryDto>> 
            UpdateEquipmentPositionHistories(Guid equipmentId, DateTime date, 
                UpdateEquipmentPositionHistoriesCommand command)
        {
            command.EquipmentId = equipmentId;
            command.Date = date;
            return await Mediator.Send(command);
        }

        [HttpDelete("{equipmentId}/{date}")]
        public async Task<ActionResult<EquipmentPositionHistoryDto>> 
            DeleteEquipmentPositionHistories(Guid equipmentId, DateTime date)
        {
            return await Mediator.Send(new DeleteEquipmentPositionHistoriesCommand 
                {EquipmentId =  equipmentId, Date = date});
        }
    }
}