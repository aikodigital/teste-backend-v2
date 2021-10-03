using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.Equipments.Commands.RequestModels;
using Application.Features.Equipments.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentsController : BaseController
    {

        [HttpPost]
        public async Task<ActionResult<EquipmentDto>> CreateEquipment(CreateEquipmentCommand command)
        {
            return await Mediator.Send(command);
        }
            
        [HttpGet]
        public async Task<IReadOnlyList<EquipmentDto>> ListEquipments()
        {
            return await Mediator.Send(new ListAllEquipmentsQuery());
        }

        [HttpGet("{equipmentId}")]
        public async Task<ActionResult<EquipmentDto>> GetEquipmentById(Guid equipmentId)
        {
            return await Mediator.Send(new GetEquipmentByIdQuery {EquipmentId = equipmentId});
        }
        
        [HttpGet("equipmentProductivityPercentage/{equipmentId}/{date}")]
        public async Task<ActionResult<string>> GetEquipmentProductivityPercentage(Guid equipmentId, 
            DateTime date)
        {
            return await Mediator.Send(new GetEquipmentProductivityPercentageQuery
                {EquipmentId = equipmentId, Date = date});
        }

        [HttpPut("{equipmentId}")]
        public async Task<ActionResult<EquipmentDto>> UpdateNameOfEquipment(Guid equipmentId, 
            UpdateEquipmentCommand command)
        {
            command.EquipmentId = equipmentId;
            return await Mediator.Send(command);
        }

        [HttpDelete("{equipmentId}")]
        public async Task<ActionResult<EquipmentDto>> DeleteEquipment(Guid equipmentId)
        {
            return await Mediator.Send(new DeleteEquipmentCommand{EquipmentId = equipmentId});
        }
    }
}