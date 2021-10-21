using System;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AikoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EquipmentStateHistoryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public EquipmentStateHistoryController(IRepositoryWrapper repository) => _repository = repository;
        
        [HttpGet]
        public async Task<ActionResult<EquipmentStateHistory>> Get()
        {
            try
            {
                var equipmentStateHistories = await _repository.EquipmentStateHistory.GetAll();
                return Ok(equipmentStateHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("date")]
        public async Task<ActionResult<EquipmentStateHistory>> GetByDate([FromBody] EquipmentStateHistory model)
        {
            try
            {
                var equipmentStateHistories = await _repository.EquipmentStateHistory.GetByDate(model.date);
                return Ok(equipmentStateHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("equipment-id/{id}")]
        public async Task<ActionResult<EquipmentStateHistory>> GetByEquipmentId([FromRoute] Guid id)
        {
            try
            {
                var equipmentStateHistories = await _repository.EquipmentStateHistory.GetByEquipmentId(id);
                return Ok(equipmentStateHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("equipment-state-id/{id}")]
        public async Task<ActionResult<EquipmentStateHistory>> GetByEquipmentStateId([FromRoute] Guid id)
        {
            try
            {
                var equipmentStateHistories = await _repository.EquipmentStateHistory.GetByEquipmentStateId(id);
                return Ok(equipmentStateHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<EquipmentStateHistory>> Post([FromBody] EquipmentStateHistory model)
        {
            try
            {
                var equipmentStateHistory = await _repository.EquipmentStateHistory.Post(model);
                return Ok(equipmentStateHistory);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentStateHistory>> Put([FromBody] EquipmentStateHistory model)
        {
            try
            {
                var equipmentStateHistory = await _repository.EquipmentStateHistory.Put(model);
                return Ok(equipmentStateHistory);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<EquipmentStateHistory>> Delete(EquipmentStateHistory model)
        {
            try
            {
                var result = await _repository.EquipmentStateHistory.Remove(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
    }
}