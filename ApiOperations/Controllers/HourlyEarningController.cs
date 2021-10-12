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
    public class HourlyEarningController : ControllerBase
    {
        private readonly IHourlyEarningRepository _repository;

        public HourlyEarningController(IHourlyEarningRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[controller]")]
        public IActionResult GetHourlysEarnings()
        {
            try
            {
                var data = _repository.GetHourlysEarnings();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpGet("[controller]/EquipmentModel={equipmentModel}")]
        public IActionResult GetHourlyEarning(string equipmentModel)
        {
            try
            {
                var data = _repository.GetHourlyEarning(equipmentModel);
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpPost("[controller]/Add")]
        public IActionResult PostHourlyEarning([FromBody] EquipmentModelStateHourlyEarning hourlyEarning)
        {
            try
            {
                var data = _repository.PostHourlyEarning(hourlyEarning);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }

        [HttpPut("[controller]/Update")]
        public IActionResult PutHourlyEarning([FromBody] EquipmentModelStateHourlyEarning hourlyEarning)
        {
            try
            {
                var data = _repository.PutHourlyEarning(hourlyEarning);
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
                var data = _repository.DeleteHourlyEarning(id);
                return Ok(data);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro interno. " + e.Message);
            }
        }
    }
}
