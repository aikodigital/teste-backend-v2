using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.EquipmentModelStateHourlyEarnings.Commands.RequestModels;
using Application.Features.EquipmentModelStateHourlyEarnings.Queries.RequestModels;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EquipmentModelStateHourlyEarningsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<EquipmentModelStateHourlyEarning>> 
            CreateEquipmentModelStateHourlyEarnings(CreateEquipmentModelStateHourlyEarningsCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarning>> 
            ListAllEquipmentModelStateHourlyEarnings()
        {
            return await Mediator.Send(new ListAllEquipmentModelStateHourlyEarningsQuery());
        }

        [HttpGet("equipmentmodel/{equipmentModelId}")]
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarning>>
            GetEquipmentModelStateHourlyEarningByEquipmentModelId(Guid equipmentModelId)
        {
            return await Mediator.Send(
                new GetEquipmentModelStateHourlyEarningByEquipmentModelIdQuery 
                    {EquipmentModelId = equipmentModelId});
        }
        
        [HttpGet("equipmentstate/{equipmentStateId}")]
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarning>>
            GetEquipmentModelStateHourlyEarningByEquipmentStateId(Guid equipmentStateId)
        {
            return await Mediator.Send(
                new GetEquipmentModelStateHourlyEarningByEquipmentStateIdQuery 
                    {EquipmentStateId = equipmentStateId});
        }
        
        [HttpGet("value/{value}")]
        public async Task<IReadOnlyList<EquipmentModelStateHourlyEarning>>
            GetEquipmentModelStateHourlyEarningByValue(float value)
        {
            return await Mediator.Send(
                new GetEquipmentModelStateHourlyEarningByValueQuery 
                    {Value = value});
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentModelStateHourlyEarning>> 
            UpdateEquipmentModelStateHourlyEarning(UpdateEquipmentModelStateHourlyEarningsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{equipmentModelId}/{equipmentStateId}")]
        public async Task<ActionResult<EquipmentModelStateHourlyEarning>>
            DeleteEquipmentModelStateHourlyEarning(Guid equipmentModelId, Guid equipmentStateId)
        {
            return await Mediator.Send(new DeleteEquipmentModelStateHourlyEarningsCommand
                {EquipmentModelId = equipmentModelId, EquipmentStateId = equipmentStateId});
        }
    }
}