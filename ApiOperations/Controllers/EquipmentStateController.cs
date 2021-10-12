using ApiOperations.Models;
using ApiOperations.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiOperations.Controllers
{
    [Route("api")]
    [ApiController]
    public class EquipmentStateController : ControllerBase
    {
        private readonly IEquipmentStateRepository _repository;

        public EquipmentStateController(IEquipmentStateRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[controller]/All")]
        public IActionResult GetEquipmentStates()
        {
            try
            {
                var data = _repository.GetEquipmentStates();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpGet("[controller]/id={id}")]
        public IActionResult GetEquipmentStates(Guid id)
        {
            try
            {
                var data = _repository.GetEquipmentState(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpGet("[controller]/name={name}")]
        public IActionResult GetEquipmentStates(string name)
        {
            try
            {
                var data = _repository.GetEquipmentState(name);
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpPost("[controller]/Add")]
        public IActionResult PostPostEquipmentState([FromBody] EquipmentState equipmentState)
        {
            try
            {
                var data = _repository.PostEquipmentState(equipmentState);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpPut("[controller]/Update")]
        public IActionResult PutEquipmentState([FromBody] EquipmentState equipmentState)
        {
            try
            {
                var data = _repository.PutEquipmentState(equipmentState);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }
        
        [HttpDelete("[controller]/Delete/{id}")]
        public IActionResult DeleteEquipmentState(Guid id)
        {
            try
            {
                var data = _repository.DeleteEquipmentState(id);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

    }
}
