using ApiOperations.Models;
using ApiOperations.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Controllers
{
    [Route("api")]
    [ApiController]
    public class PositionHistoryController : ControllerBase
    {
        private readonly IPositionHistoryRepository _repository;

        public PositionHistoryController(IPositionHistoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[controller]/Equipment={id}")]
        public IActionResult GetPositionHistories(Guid id)
        {
            try
            {
                var data = _repository.GetPositionHistories(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpPost("[controller]/Add")]
        public IActionResult PostHourlyEarning([FromBody] EquipmentPositionHistory positionHistory)
        {
            try
            {
                var data = _repository.PostPositionHistory(positionHistory);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpPut("[controller]/Update")]
        public IActionResult PutHourlyEarning([FromBody] EquipmentPositionHistory positionHistory)
        {
            try
            {
                var data = _repository.PutPositionHistory(positionHistory);
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
                var data = _repository.DeletePositionHistory(id);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }
    }
}
