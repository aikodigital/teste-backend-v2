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
    public class EquipmentStateHistoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentStateHistoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentStateHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistory>>> Getequipment_state_history()
        {
            return await _context.equipment_state_history.ToListAsync();
        }

        // GET: api/EquipmentStateHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentStateHistory>> GetEquipmentStateHistory(Guid id)
        {
            var equipmentStateHistory = await _context.equipment_state_history.FindAsync(id);

            if (equipmentStateHistory == null)
            {
                return NotFound();
            }

            return equipmentStateHistory;
        }

        // PUT: api/EquipmentStateHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentStateHistory(Guid id, EquipmentStateHistory equipmentStateHistory)
        {
            if (id != equipmentStateHistory.EquipmentId)
            {
                return BadRequest();
            }

            _context.Entry(equipmentStateHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentStateHistoryExists(id))
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

        // POST: api/EquipmentStateHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentStateHistory>> PostEquipmentStateHistory(EquipmentStateHistory equipmentStateHistory)
        {
            _context.equipment_state_history.Add(equipmentStateHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentStateHistoryExists(equipmentStateHistory.EquipmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentStateHistory", new { id = equipmentStateHistory.EquipmentId }, equipmentStateHistory);
        }

        // DELETE: api/EquipmentStateHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentStateHistory(Guid id)
        {
            var equipmentStateHistory = await _context.equipment_state_history.FindAsync(id);
            if (equipmentStateHistory == null)
            {
                return NotFound();
            }

            _context.equipment_state_history.Remove(equipmentStateHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentStateHistoryExists(Guid id)
        {
            return _context.equipment_state_history.Any(e => e.EquipmentId == id);
        }
    }
}
