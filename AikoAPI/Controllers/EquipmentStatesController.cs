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
    public class EquipmentStatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentStatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentState>>> Getequipment_state()
        {
            return await _context.equipment_state.ToListAsync();
        }

        // GET: api/EquipmentStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentState>> GetEquipmentState(Guid id)
        {
            var equipmentState = await _context.equipment_state.FindAsync(id);

            if (equipmentState == null)
            {
                return NotFound();
            }

            return equipmentState;
        }

        // PUT: api/EquipmentStates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentState(Guid id, EquipmentState equipmentState)
        {
            if (id != equipmentState.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentStateExists(id))
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

        // POST: api/EquipmentStates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentState>> PostEquipmentState(EquipmentState equipmentState)
        {
            _context.equipment_state.Add(equipmentState);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentState", new { id = equipmentState.Id }, equipmentState);
        }

        // DELETE: api/EquipmentStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentState(Guid id)
        {
            var equipmentState = await _context.equipment_state.FindAsync(id);
            if (equipmentState == null)
            {
                return NotFound();
            }

            _context.equipment_state.Remove(equipmentState);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentStateExists(Guid id)
        {
            return _context.equipment_state.Any(e => e.Id == id);
        }
    }
}
