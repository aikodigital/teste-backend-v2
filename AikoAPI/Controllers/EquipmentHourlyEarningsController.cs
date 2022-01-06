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

        // GET: api/EquipmentHourlyEarnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentHourlyEarnings>>> Getequipment_model_state_hourly_earnings()
        {
            return await _context.equipment_model_state_hourly_earnings.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentHourlyEarnings>>> GetEquipmentHourlyEarningsByModelId([FromQuery] Guid modelId)
        {
            var equipmentHourlyEarnings = await _context.equipment_model_state_hourly_earnings.Where(ehe => ehe.EquipmentModelId == modelId).ToListAsync();

            if (equipmentHourlyEarnings == null)
            {
                return NotFound();
            }

            return equipmentHourlyEarnings;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentHourlyEarnings>>> GetEquipmentHourlyEarningsByStateId([FromQuery] Guid stateId)
        {
            var equipmentHourlyEarnings = await _context.equipment_model_state_hourly_earnings.Where(ehe => ehe.EquipmentStateId == stateId).ToListAsync();

            if (equipmentHourlyEarnings == null)
            {
                return NotFound();
            }

            return equipmentHourlyEarnings;
        }

        // PUT: api/EquipmentHourlyEarnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{modelId}, {stateId}")]
        public async Task<IActionResult> PutEquipmentHourlyEarnings(Guid modelId, Guid stateId, EquipmentHourlyEarnings equipmentHourlyEarnings)
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

        // POST: api/EquipmentHourlyEarnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentHourlyEarnings>> PostEquipmentHourlyEarnings(EquipmentHourlyEarnings equipmentHourlyEarnings)
        {
            _context.equipment_model_state_hourly_earnings.Add(equipmentHourlyEarnings);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentHourlyEarningsExists(equipmentHourlyEarnings.EquipmentModelId, equipmentHourlyEarnings.EquipmentStateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentHourlyEarnings", new { id = equipmentHourlyEarnings.EquipmentModelId }, equipmentHourlyEarnings);
        }

        // DELETE: api/EquipmentHourlyEarnings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentHourlyEarnings(Guid id)
        {
            var equipmentHourlyEarnings = await _context.equipment_model_state_hourly_earnings.FindAsync(id);
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
            return _context.equipment_model_state_hourly_earnings.Any(e => e.EquipmentModelId == modelId && e.EquipmentStateId == stateId);
        }
    }
}
