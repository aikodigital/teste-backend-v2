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

        // GET: api/EquipmentHourlyEarnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentHourlyEarnings>> GetEquipmentHourlyEarnings(Guid id)
        {
            var equipmentHourlyEarnings = await _context.equipment_model_state_hourly_earnings.FindAsync(id);

            if (equipmentHourlyEarnings == null)
            {
                return NotFound();
            }

            return equipmentHourlyEarnings;
        }

        // PUT: api/EquipmentHourlyEarnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentHourlyEarnings(Guid id, EquipmentHourlyEarnings equipmentHourlyEarnings)
        {
            if (id != equipmentHourlyEarnings.EquipmentModelId)
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
                if (!EquipmentHourlyEarningsExists(id))
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
                if (EquipmentHourlyEarningsExists(equipmentHourlyEarnings.EquipmentModelId))
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

        private bool EquipmentHourlyEarningsExists(Guid id)
        {
            return _context.equipment_model_state_hourly_earnings.Any(e => e.EquipmentModelId == id);
        }
    }
}
