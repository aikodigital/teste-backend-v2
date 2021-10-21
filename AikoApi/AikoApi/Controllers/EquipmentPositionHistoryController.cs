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
    public class EquipmentPositionHistoryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public EquipmentPositionHistoryController(IRepositoryWrapper repository) => _repository = repository;
        
        [HttpGet]
        public async Task<ActionResult<EquipmentPositionHistory>> Get()
        {
            try
            {
                var equipmentPositionHistories = await _repository.EquipmentPositionHistory.GetAll();
                return Ok(equipmentPositionHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("equipment-id/{id}")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetByEquipmentId([FromRoute] Guid id)
        {
            try
            {
                var equipmentPositionHistory = await _repository.EquipmentPositionHistory.GetByEquipmentId(id);
                return Ok(equipmentPositionHistory);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("position")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetByPosition([FromBody] Position model)
        {
            try
            {
                var equipmentPositionHistories = await _repository.EquipmentPositionHistory.GetByPosition(model);
                return Ok(equipmentPositionHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("date")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetByDate([FromBody] EquipmentPositionHistory model)
        {
            try
            {
                var equipmentPositionHistories = await _repository.EquipmentPositionHistory.GetByDate(model.date);
                return Ok(equipmentPositionHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("latitude")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetByLatitude([FromBody] Position model)
        {
            try
            {
                var equipmentPositionHistories = await _repository.EquipmentPositionHistory.GetByLatitude(model.lat);
                return Ok(equipmentPositionHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("longitude")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetByLongitude([FromBody] Position model)
        {
            try
            {
                var equipmentPositionHistories = await _repository.EquipmentPositionHistory.GetByLongitude(model.lon);
                return Ok(equipmentPositionHistories);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<EquipmentPositionHistory>> Post([FromBody] EquipmentPositionHistory model)
        {
            try
            {
                var equipmentPositionHistory = await _repository.EquipmentPositionHistory.Post(model);
                return Ok(equipmentPositionHistory);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult<EquipmentPositionHistory>> Put([FromBody] EquipmentPositionHistory model)
        {
            try
            {
                var equipmentPositionHistory = await _repository.EquipmentPositionHistory.Put(model);
                return Ok(equipmentPositionHistory);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult<EquipmentPositionHistory>> Delete([FromBody] EquipmentPositionHistory model)
        {
            try
            {
                var result = await _repository.EquipmentPositionHistory.Remove(model);
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