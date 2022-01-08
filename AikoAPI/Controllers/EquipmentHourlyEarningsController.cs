using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AikoAPI;
using AikoAPI.Models;

namespace AikoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentHourlyEarningsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentHourlyEarningsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma lista com os valores de ganho de todos os equipamentos por estado
        /// </summary>
        /// <response code="200">Caso a lista seja gerada com sucesso</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentHourlyEarnings>>> Getequipment_model_state_hourly_earnings()
        {
            return await _context.equipment_model_state_hourly_earnings.ToListAsync();
        }

        /// <summary>
        /// Retorna uma lista com os valores de ganho de um modelo específico
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("modelId")]
        public async Task<ActionResult<IEnumerable<EquipmentHourlyEarnings>>> GetEquipmentHourlyEarningsByModelId(Guid modelId)
        {
            var equipmentHourlyEarnings = await _context.equipment_model_state_hourly_earnings.Where(ehe => ehe.EquipmentModelId == modelId).ToListAsync();

            if (equipmentHourlyEarnings.Count == 0)
            {
                return NotFound();
            }

            return equipmentHourlyEarnings;
        }

        /// <summary>
        /// Retorna uma lista com os valores de ganho de um modelo e de um estado específico
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("byModelAndState")]
        public async Task<ActionResult<IEnumerable<EquipmentHourlyEarnings>>> GetEquipmentHourlyEarningsByModelAndState([FromQuery] Guid modelId, [FromQuery] Guid stateId)
        {
            var equipmentHourlyEarnings = await _context.equipment_model_state_hourly_earnings.Where(ehe => ehe.EquipmentModelId == modelId && ehe.EquipmentStateId == stateId).ToListAsync();

            if (equipmentHourlyEarnings.Count == 0)
            {
                return NotFound();
            }

            return equipmentHourlyEarnings;
        }

        /// <summary>
        /// Atualiza o cadastro de um ganho
        /// </summary>
        /// <response code="204">Caso o objeto seja atualizado com sucesso</response>
        /// <response code="400">Caso o id do modelo ou o id do estado informados não sejam os mesmos do payload ou outro problema nos dados informados</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpPut] 
        public async Task<IActionResult> PutEquipmentHourlyEarnings([FromQuery] Guid modelId, [FromQuery] Guid stateId, EquipmentHourlyEarnings equipmentHourlyEarnings)
        {
            if (modelId != equipmentHourlyEarnings.EquipmentModelId)
            {
                return BadRequest();
            }

            if (stateId != equipmentHourlyEarnings.EquipmentStateId)
            {
                return BadRequest();
            }

            _context.Entry(equipmentHourlyEarnings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentHourlyEarningsExists(modelId, stateId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Insere um novo ganho
        /// </summary>
        /// <response code="201">Caso o objeto seja inserido com sucesso</response>
        /// <response code="400">Caso haja algum problema com um dos campos do payload</response>
        /// <response code="409">Caso o objeto já exista</response>
        /// <response code="500">Caso o modelo ou estado informados não existam no banco de dados</response>
        [HttpPost]
        public async Task<ActionResult<EquipmentHourlyEarnings>> PostEquipmentHourlyEarnings(EquipmentHourlyEarnings equipmentHourlyEarnings)
        {
            _context.equipment_model_state_hourly_earnings.Add(equipmentHourlyEarnings);

            if (EquipmentHourlyEarningsExists(equipmentHourlyEarnings.EquipmentModelId, equipmentHourlyEarnings.EquipmentStateId))
            {
                return Conflict();
            }
            else
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }            

            return CreatedAtAction("GetEquipmentHourlyEarningsByModelAndState", new { modelId = equipmentHourlyEarnings.EquipmentModelId, stateId = equipmentHourlyEarnings.EquipmentStateId }, equipmentHourlyEarnings);
        }

        /// <summary>
        /// Remove um ganho
        /// </summary>
        /// <response code="204">Caso o objeto seja deletado com sucesso</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpDelete()]
        public async Task<IActionResult> DeleteEquipmentHourlyEarnings([FromQuery] Guid modelId, [FromQuery] Guid stateId)
        {
            var equipmentHourlyEarnings = await _context.equipment_model_state_hourly_earnings.FindAsync(modelId, stateId);
            if (equipmentHourlyEarnings == null)
            {
                return NotFound();
            }

            _context.equipment_model_state_hourly_earnings.Remove(equipmentHourlyEarnings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentHourlyEarningsExists(Guid modelId, Guid stateId)
        {
            return _context.equipment_model_state_hourly_earnings.Any(e => (e.EquipmentModelId == modelId && e.EquipmentStateId == stateId));
        }
    }
}
