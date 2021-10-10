using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.EquipmentModels.Commands.RequestModels;
using Application.Features.EquipmentModels.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentModelsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<EquipmentModel>> CreateEquipmentModel(CreateEquipmentModelCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IReadOnlyList<EquipmentModel>> ListAllEquipmentModels()
        {
            return await Mediator.Send(new ListAllEquipmentModelsQuery());
        }

        [HttpGet("{equipmentModelId}")]
        public async Task<ActionResult<EquipmentModel>> GetEquipmentModelById(Guid equipmentModelId)
        {
            return await Mediator.Send(new GetEquipmentModelByIdQuery {EquipmentModelId = equipmentModelId});
        }
        
        [HttpPut("{equipmentModelId}")]
        public async Task<ActionResult<EquipmentModel>> UpdateEquipmentModel(Guid equipmentModelId, UpdateEquipmentModelCommand command)
        {
            command.EquipmentModelId = equipmentModelId;
            return await Mediator.Send(command);
        }
        
        [HttpDelete("{equipmentModelId}")]
        public async Task<ActionResult<EquipmentModel>> DeleteEquipmentModel(Guid equipmentModelId)
        {
            return await Mediator.Send(new DeleteEquipmentModelCommand {EquipmentModelId = equipmentModelId});
        }
        
    }
}