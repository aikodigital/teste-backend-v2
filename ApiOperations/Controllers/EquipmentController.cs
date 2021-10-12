using ApiOperations.Models;
using ApiOperations.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace ApiOperations.Controllers
{
    [Route("api")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentController(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[controller]/All")]
        public IActionResult GetEquipments()
        {
            try
            {
                var data = _repository.GetEquipments();
                Log.Information("GetEquipments executed.");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Internal error.");
            }
        }

        [HttpGet("[controller]/id={id}")]
        public IActionResult GetEquipment(Guid id)
        {
            try
            {
                var data = _repository.GetEquipment(id);
                Log.Information($"GetEquipment id[{id}] executed.");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Internal error.");
            }

        }

        [HttpGet("[controller]/name={name}")]
        public IActionResult GetEquipment(string name)
        {
            try
            {
                var data = _repository.GetEquipment(name);
                Log.Information($"GetEquipment name[{name}] executed.");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Internal error.");
            }

        }

        [HttpPost("[controller]/Add")]
        public IActionResult PostEquipment([FromBody] Equipment equipment)
        {
            try
            {
                equipment.Id = Guid.NewGuid();
                var data = _repository.PostEquipment(equipment);
                Log.Information("PostEquipment executed.");
                return StatusCode(201, data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Internal error.");
            }
        }

        [HttpPut("[controller]/Update")]
        public IActionResult PutEquipment([FromBody] Equipment equipment)
        {
            try
            {
                var data = _repository.PutEquipment(equipment);
                Log.Information($"PutEquipment executed.");
                return StatusCode(200, data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Internal error.");
            }
        }

        [HttpDelete("[controller]/Delete/{id}")]
        public IActionResult DeleteEquipment(Guid id)
        {
            try
            {
                var data = _repository.DeleteEquipment(id);
                Log.Information($"DeleteEquipment Id[{id}] executed.");
                return StatusCode(200, data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Internal error.");
            }
        }

    }
}
