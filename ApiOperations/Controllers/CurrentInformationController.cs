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
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentInformationController : ControllerBase
    {
        private readonly IStateHistoryRepository _stateHistory;
        private readonly IPositionHistoryRepository _positionHistory;

        public CurrentInformationController(IStateHistoryRepository stateHistory, IPositionHistoryRepository positionHistory)
        {
            _stateHistory = stateHistory;
            _positionHistory = positionHistory;
        }

        [HttpGet("LastState/equipment={id}")]
        public IActionResult GetLastState(Guid id)
        {
            try
            {
                var data = _stateHistory.GetLastState(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "");
            }
        }
        [HttpGet("LastPosition/equipment={id}")]
        public IActionResult GetLastPosition(Guid id)
        {
            try
            {
                var data = _positionHistory.GetLastPosition(id);

                return Ok(data);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return StatusCode(500, "");
            }
        }
    }
}
