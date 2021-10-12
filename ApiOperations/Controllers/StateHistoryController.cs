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
    public class StateHistoryController : ControllerBase
    {
        private readonly IStateHistoryRepository _repository;

        public StateHistoryController(IStateHistoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[controller]/Equipment={id}")]
        public IActionResult GetStateHistories(Guid id)
        {
            try
            {
                var data = _repository.GetStateHistories(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpPost("[controller]/Add")]
        public IActionResult PostHourlyEarning([FromBody] EquipmentStateHistory stateHistory)
        {
            try
            {
                var data = _repository.PostStateHistory(stateHistory);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpPut("[controller]/Update")]
        public IActionResult PutHourlyEarning([FromBody] EquipmentStateHistory stateHistory)
        {
            try
            {
                var data = _repository.PutStateHistory(stateHistory);
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
                var data = _repository.DeleteStateHistory(id);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

    }
}
