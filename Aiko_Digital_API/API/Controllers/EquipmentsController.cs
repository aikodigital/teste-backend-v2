using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Equipments.Commands.RequestModels;
using Application.Features.Equipments.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentsController : BaseController
    {

        [HttpPost]
        public async Task<ActionResult<Equipment>> CreateEquipment(CreateEquipmentCommand command)
        {
            return await Mediator.Send(command);
        }
            
        [HttpGet]
        public async Task<IReadOnlyList<Equipment>> ListEquipments()
        {
            return await Mediator.Send(new ListAllEquipmentsQuery());
        }

        [HttpGet("{equipmentId}")]
        public async Task<ActionResult<Equipment>> GetEquipmentById(Guid equipmentId)
        {
            return await Mediator.Send(new GetEquipmentByIdQuery {EquipmentId = equipmentId});
        }

        [HttpPut("{equipmentId}")]
        public async Task<ActionResult<Equipment>> UpdateNameOfEquipment(Guid equipmentId, 
            UpdateEquipmentCommand command)
        {
            command.EquipmentId = equipmentId;
            return await Mediator.Send(command);
        }

        [HttpDelete("{equipmentId}")]
        public async Task<ActionResult<Equipment>> DeleteEquipment(Guid equipmentId)
        {
            return await Mediator.Send(new DeleteEquipmentCommand{EquipmentId = equipmentId});
        }
    }
}