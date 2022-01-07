using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AikoAPI;
using AikoAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                
        // GET: api/EquipmentStateHistories/5
        [HttpGet("{equipmentId}")]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistory>>> GetEquipmentStateHistory(Guid equipmentId)
        {
            var equipmentStateHistory = await _context.equipment_state_history.Where(esh => esh.EquipmentId == equipmentId).ToListAsync();

            if (equipmentStateHistory == null)
            {
                return NotFound();
            }

            return equipmentStateHistory;
        }

        [HttpGet("byEquipmentAndDate")]
        public async Task<ActionResult<EquipmentStateHistory>> GetEquipmentStateHistoryByEquipmentAndDate(Guid equipmentId, String date)
        {
            var equipmentStateHistory = await _context.equipment_state_history.Where(esh => esh.EquipmentId == equipmentId && esh.Date == DateTime.Parse(date)).ToListAsync();

            if (equipmentStateHistory.Count == 0)
            {
                return NotFound();
            }

            return equipmentStateHistory[0];
        }

        // PUT: api/EquipmentStateHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutEquipmentStateHistory([FromQuery] Guid equipmentId, [FromQuery] String date, EquipmentStateHistory equipmentStateHistory)
        { 
            if (equipmentId != equipmentStateHistory.EquipmentId || DateTime.Parse(date) != equipmentStateHistory.Date)
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
                if (!EquipmentStateHistoryExists(equipmentId, equipmentStateHistory.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
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
                if (EquipmentStateHistoryExists(equipmentStateHistory.EquipmentId, equipmentStateHistory.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentStateHistory", new { equipmentId = equipmentStateHistory.EquipmentId, date = equipmentStateHistory.Date }, equipmentStateHistory);
        }

        // DELETE: api/EquipmentStateHistories/5
        [HttpDelete]
        public async Task<IActionResult> DeleteEquipmentStateHistory([FromQuery] Guid equipmentId, [FromQuery] String date)
        {
            var equipmentStateHistory = await _context.equipment_state_history.FindAsync(equipmentId, DateTime.Parse(date));
            if (equipmentStateHistory == null)
            {
                return NotFound();
            }

            _context.equipment_state_history.Remove(equipmentStateHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentStateHistoryExists(Guid id, String date)
        {
            return _context.equipment_state_history.Any(e => e.EquipmentId == id && e.Date == DateTime.Parse(date));
        }
    }
}
