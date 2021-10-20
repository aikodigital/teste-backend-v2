using System;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AikoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentModelController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        
        public EquipmentModelController(IRepositoryWrapper repository) => _repository = repository;
        
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var equipmentModels = await _repository.EquipmentModel.GetAll();
                return Ok(equipmentModels);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var equipmentModel = await _repository.EquipmentModel.GetById(id);
                return Ok(equipmentModel);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> Get(string name)
        {
            try
            {
                var equipmentModels = await _repository.EquipmentModel.GetByName(name);
                return Ok(equipmentModels);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EquipmentModel model)
        {
            try
            {
                var equipmentModel = await _repository.EquipmentModel.Post(model);
                return Ok(equipmentModel);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EquipmentModel model)
        {
            try
            {
                var equipmentModel = await _repository.EquipmentModel.Put(model);
                return Ok(equipmentModel);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(EquipmentModel model)
        {
            try
            {
                var result = await _repository.EquipmentModel.Remove(model);
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
