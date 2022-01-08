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

        // GET: api/EquipmentPositionHistories/5
        [HttpGet("{equipmentId}")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistory>>> GetEquipmentPositionHistory(Guid equipmentId)
        {
            var equipmentPositionHistory = await _context.equipment_position_history.Where(eph => eph.EquipmentId == equipmentId).ToListAsync();

            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            return equipmentPositionHistory;
        }

        [HttpGet("byEquipmentAndDate")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetEquipmentPositionHistoryByEquipmentAndDate(Guid equipmentId, String date)
        {
            var EquipmentPositionHistory = await _context.equipment_position_history.Where(eph => eph.EquipmentId == equipmentId && eph.Date == DateTime.Parse(date)).ToListAsync();

            if (EquipmentPositionHistory.Count == 0)
            {
                return NotFound();
            }

            return EquipmentPositionHistory[0];
        }

        [HttpGet("currentPosition")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistory>>> GetEquipmentPositionHistoryCurrentState()
        {
            var equipmentPositionHistory = _context.equipment_position_history
                .Include(e => e.Equipment)
                .AsEnumerable()
                .GroupBy(e => e.EquipmentId)
                .Select(g => g.OrderByDescending(g => g.Date).FirstOrDefault())
                .ToList();

            if (equipmentPositionHistory.Count == 0)
            {
                return NotFound();
            }

            return equipmentPositionHistory;
        }

        // PUT: api/EquipmentPositionHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutEquipmentPositionHistory([FromQuery] Guid equipmentId, [FromQuery] String date, EquipmentPositionHistory equipmentPositionHistory)
        {
            if (equipmentId != equipmentPositionHistory.EquipmentId || DateTime.Parse(date) != equipmentPositionHistory.Date)
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
                if (!EquipmentPositionHistoryExists(equipmentId, equipmentPositionHistory.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
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
        public async Task<ActionResult<EquipmentStateHistory>> PostEquipmentPositionHistory(EquipmentPositionHistory equipmentPositionHistory)
        {
            _context.equipment_position_history.Add(equipmentPositionHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentPositionHistoryExists(equipmentPositionHistory.EquipmentId, equipmentPositionHistory.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentPositionHistory", new { equipmentId = equipmentPositionHistory.EquipmentId, date = equipmentPositionHistory.Date }, equipmentPositionHistory);
        }

        // DELETE: api/EquipmentPositionHistories/5
        [HttpDelete]
        public async Task<IActionResult> DeleteEquipmentPositionHistory([FromQuery] Guid equipmentId, [FromQuery] String date)
        {
            var equipmentPositionHistory = await _context.equipment_position_history.FindAsync(equipmentId, DateTime.Parse(date));
            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            _context.equipment_position_history.Remove(equipmentPositionHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentPositionHistoryExists(Guid id, String date)
        {
            return _context.equipment_position_history.Any(e => e.EquipmentId == id && e.Date == DateTime.Parse(date));
        }
    }
}
