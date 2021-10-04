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
    public class EquipmentPositionHistoriesController : ControllerBase
    {
        private readonly EquipmentPositionHistoryContext _context;

        public EquipmentPositionHistoriesController(EquipmentPositionHistoryContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentPositionHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistory>>> GetEquipmentPositionHistories()
        {
            return await _context.EquipmentPositionHistories.ToListAsync();
        }

        // GET: api/EquipmentPositionHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetEquipmentPositionHistory(Guid id, DateTime date)
        {
            var equipmentPositionHistory = await _context.EquipmentPositionHistories.FindAsync(id, date);

            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            return equipmentPositionHistory;
        }

        // PUT: api/EquipmentPositionHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentPositionHistory(Guid id, DateTime date, EquipmentPositionHistory equipmentPositionHistory)
        {
            if (id != equipmentPositionHistory.equipment_id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentPositionHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentPositionHistoryExists(id, date))
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

        // POST: api/EquipmentPositionHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentPositionHistory>> PostEquipmentPositionHistory(EquipmentPositionHistory equipmentPositionHistory)
        {
            _context.EquipmentPositionHistories.Add(equipmentPositionHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentPositionHistoryExists(equipmentPositionHistory.equipment_id, equipmentPositionHistory.date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentPositionHistory", new { id = equipmentPositionHistory.equipment_id }, equipmentPositionHistory);
        }

        // DELETE: api/EquipmentPositionHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentPositionHistory(Guid id, DateTime date)
        {
            var equipmentPositionHistory = await _context.EquipmentPositionHistories.FindAsync(id, date);
            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            _context.EquipmentPositionHistories.Remove(equipmentPositionHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentPositionHistoryExists(Guid id, DateTime date)
        {
            return _context.EquipmentPositionHistories.Any(e => e.equipment_id == id && e.date == date);
        }
    }
}
