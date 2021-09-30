using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.EquipmentStates.Commands.RequestModels;
using Application.Features.EquipmentStates.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentStatesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<EquipmentState>> CreateEquipmentState(CreateEquipmentStateCommand 
            command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<IReadOnlyList<EquipmentState>> ListAllEquipmentState()
        {
            return await Mediator.Send(new ListAllEquipmentStatesQuery());
        }

        [HttpGet("{equipmentStateId}")]
        public async Task<ActionResult<EquipmentState>> GetEquipmentStateById(Guid equipmentStateId)
        {
            return await Mediator.Send(new GetEquipmentStateByIdQuery 
                {EquipmentStateId = equipmentStateId});
        }

        [HttpPut("{equipmentStateId}")]
        public async Task<ActionResult<EquipmentState>> UpdateEquipmentState(Guid equipmentStateId,
            UpdateEquipmentStateCommand command)
        {
            command.EquipmentStateId = equipmentStateId;
            return await Mediator.Send(command);
        }

        [HttpDelete("{equipmentStateId}")]
        public async Task<ActionResult<EquipmentState>> DeleteEquipmentState(Guid equipmentStateId)
        {
            return await Mediator.Send(new DeleteEquipmentStateCommand 
                {EquipmentStateId = equipmentStateId});
        }
    }
}