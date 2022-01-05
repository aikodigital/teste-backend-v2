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
    public class EquipmentPositionHistoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentPositionHistoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentPositionHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistory>>> Getequipment_position_history()
        {
            return await _context.equipment_position_history.ToListAsync();
        }

        // GET: api/EquipmentPositionHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetEquipmentPositionHistory(Guid id)
        {
            var equipmentPositionHistory = await _context.equipment_position_history.FindAsync(id);

            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            return equipmentPositionHistory;
        }

        // PUT: api/EquipmentPositionHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentPositionHistory(Guid id, EquipmentPositionHistory equipmentPositionHistory)
        {
            if (id != equipmentPositionHistory.EquipmentId)
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
                if (!EquipmentPositionHistoryExists(id))
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
            _context.equipment_position_history.Add(equipmentPositionHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentPositionHistoryExists(equipmentPositionHistory.EquipmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentPositionHistory", new { id = equipmentPositionHistory.EquipmentId }, equipmentPositionHistory);
        }

        // DELETE: api/EquipmentPositionHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentPositionHistory(Guid id)
        {
            var equipmentPositionHistory = await _context.equipment_position_history.FindAsync(id);
            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            _context.equipment_position_history.Remove(equipmentPositionHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentPositionHistoryExists(Guid id)
        {
            return _context.equipment_position_history.Any(e => e.EquipmentId == id);
        }
    }
}
