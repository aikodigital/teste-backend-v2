﻿using System;
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
    public class EquipmentStateHistoriesController : ControllerBase
    {
        private readonly EquipmentStateHistoryContext _context;

        public EquipmentStateHistoriesController(EquipmentStateHistoryContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentStateHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistory>>> GetEquipmentStateHistories()
        {
            return await _context.EquipmentStateHistories.ToListAsync();
        }

        // GET: api/EquipmentStateHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentStateHistory>> GetEquipmentStateHistory(Guid id)
        {
            var equipmentStateHistory = await _context.EquipmentStateHistories.FindAsync(id);

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
            if (id != equipmentStateHistory.equipment_id)
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
            _context.EquipmentStateHistories.Add(equipmentStateHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentStateHistoryExists(equipmentStateHistory.equipment_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentStateHistory", new { id = equipmentStateHistory.equipment_id }, equipmentStateHistory);
        }

        // DELETE: api/EquipmentStateHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentStateHistory(Guid id)
        {
            var equipmentStateHistory = await _context.EquipmentStateHistories.FindAsync(id);
            if (equipmentStateHistory == null)
            {
                return NotFound();
            }

            _context.EquipmentStateHistories.Remove(equipmentStateHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentStateHistoryExists(Guid id)
        {
            return _context.EquipmentStateHistories.Any(e => e.equipment_id == id);
        }
    }
}
