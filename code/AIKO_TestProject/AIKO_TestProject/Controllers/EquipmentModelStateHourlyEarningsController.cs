using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using AIKO_TestProject.Models;

namespace AIKO_TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentModelStateHourlyEarningsController : ControllerBase
    {
        private readonly EquipmentModelStateHourlyEarningsContext _context;

        public EquipmentModelStateHourlyEarningsController(EquipmentModelStateHourlyEarningsContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentModelStateHourlyEarnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentModelStateHourlyEarnings>>> GetEquipmentModelStateHourlyEarnings()
        {
            return await _context.EquipmentModelStateHourlyEarnings.ToListAsync();
        }

        // GET: api/EquipmentModelStateHourlyEarnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentModelStateHourlyEarnings>> GetEquipmentModelStateHourlyEarnings(Guid id, Single value)
        {
            var equipmentModelStateHourlyEarnings = await _context.EquipmentModelStateHourlyEarnings.FindAsync(id, value);

            if (equipmentModelStateHourlyEarnings == null)
            {
                return NotFound();
            }

            return equipmentModelStateHourlyEarnings;
        }

        // PUT: api/EquipmentModelStateHourlyEarnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentModelStateHourlyEarnings(Guid id, Single value, EquipmentModelStateHourlyEarnings equipmentModelStateHourlyEarnings)
        {
            if (id != equipmentModelStateHourlyEarnings.equipment_model_id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentModelStateHourlyEarnings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentModelStateHourlyEarningsExists(id, value))
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

        // POST: api/EquipmentModelStateHourlyEarnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentModelStateHourlyEarnings>> PostEquipmentModelStateHourlyEarnings(EquipmentModelStateHourlyEarnings equipmentModelStateHourlyEarnings)
        {
            _context.EquipmentModelStateHourlyEarnings.Add(equipmentModelStateHourlyEarnings);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentModelStateHourlyEarningsExists(equipmentModelStateHourlyEarnings.equipment_model_id, equipmentModelStateHourlyEarnings.value))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentModelStateHourlyEarnings", new { id = equipmentModelStateHourlyEarnings.equipment_model_id }, equipmentModelStateHourlyEarnings);
        }

        // DELETE: api/EquipmentModelStateHourlyEarnings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentModelStateHourlyEarnings(Guid id, Single value)
        {
            var equipmentModelStateHourlyEarnings = await _context.EquipmentModelStateHourlyEarnings.FindAsync(id, value);
            if (equipmentModelStateHourlyEarnings == null)
            {
                return NotFound();
            }

            _context.EquipmentModelStateHourlyEarnings.Remove(equipmentModelStateHourlyEarnings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentModelStateHourlyEarningsExists(Guid id, Single value)
        {
            return _context.EquipmentModelStateHourlyEarnings.Any(e => e.equipment_model_id == id && e.value == value);
        }
    }
}
