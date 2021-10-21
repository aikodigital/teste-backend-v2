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
    public class EquipmentController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        
        public EquipmentController(IRepositoryWrapper repository) => _repository = repository;
        
        [HttpGet]
        public async Task<ActionResult<Equipment>> Get()
        {
            try
            {
                var equipments = await _repository.Equipment.GetAll();
                return Ok(equipments);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetById([FromRoute] Guid id)
        {
            try
            {
                var equipments = await _repository.Equipment.GetById(id);
                return Ok(equipments);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Equipment>> GetByName(string name)
        {
            try
            {
                var equipments = await _repository.Equipment.GetByName(name);
                return Ok(equipments);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("equipment-model/{id}")]
        public async Task<ActionResult<Equipment>> GetByEquipmentModelId([FromRoute] Guid id)
        {
            try
            {
                var equipments = await _repository.Equipment.GetByEquipmentModelId(id);
                return Ok(equipments);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Equipment>> Post([FromBody] Equipment model)
        {
            try
            {
                var equipment = await _repository.Equipment.Post(model);
                return Ok(equipment);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Equipment>> Put([FromBody] Equipment model)
        {
            try
            {
                var equipment = await _repository.Equipment.Put(model);
                return Ok(equipment);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Equipment>> Delete(Equipment model)
        {
            try
            {
                var result = await _repository.Equipment.Remove(model);
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
