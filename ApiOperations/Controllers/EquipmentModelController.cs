using ApiOperations.Models;
using ApiOperations.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Controllers
{
    [Route("api")]
    [ApiController]
    public class EquipmentModelController : ControllerBase
    {
        private readonly IEquipmentModelRepository _repository;

        public EquipmentModelController(IEquipmentModelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[controller]/All")]
        public IActionResult GetEquipmentModels()
        {
            try
            {
                var data = _repository.GetEquipmentModels();
                Log.Information("GetEquipmentModels executed");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Erro interno.");
            }
        }

        [HttpGet("[controller]/id={id}")]
        public IActionResult GetEquipmentModel(Guid id)
        {
            try
            {
                var data = _repository.GetEquipmentModel(id);
                Log.Information($"GetEquipmentModel Id[{id}] executed.");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Erro interno.");
            }
        }

        [HttpGet("[controller]/name={name}")]
        public IActionResult GetEquipmentModel(string name)
        {
            try
            {
                var data = _repository.GetEquipmentModel(name);
                Log.Information($"GetEquipmentModel Name[{name}] executed.");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Erro interno.");
            }
        }

        [HttpPost("[controller]/Add")]
        public IActionResult PostEquipmentModel([FromBody] EquipmentModel equipmentModel)
        {
            try
            {
                var data = _repository.PostEquipmentModel(equipmentModel);
                Log.Information("PostEquipmentModel executed.");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Erro interno.");
            }
        }

        [HttpPut("[controller]/Update")]
        public IActionResult PutEquipmentState([FromBody] EquipmentModel equipmentModel)
        {
            try
            {
                var data = _repository.PutEquipmentModel(equipmentModel);
                Log.Information("PutEquipmentModel executed.");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Erro interno.");
            }
        }

        [HttpDelete("[controller]/Delete/{id}")]
        public IActionResult DeleteEquipmentModel(Guid id)
        {
            try
            {
                var data = _repository.DeleteEquipmentModel(id);
                Log.Information($"DeleteEquipmentModel Id[{id}] executed.");
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "Erro interno.");
            }
        }

    }
}
