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
    public class EquipmentStatesController : ControllerBase
    {
        private readonly EquipmentStateContext _context;

        public EquipmentStatesController(EquipmentStateContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentState>>> GetEquipmentStates()
        {
            return await _context.EquipmentStates.ToListAsync();
        }

        // GET: api/EquipmentStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentState>> GetEquipmentState(Guid id)
        {
            var equipmentState = await _context.EquipmentStates.FindAsync(id);

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
            if (id != equipmentState.id)
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
            _context.EquipmentStates.Add(equipmentState);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentState", new { id = equipmentState.id }, equipmentState);
        }

        // DELETE: api/EquipmentStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentState(Guid id)
        {
            var equipmentState = await _context.EquipmentStates.FindAsync(id);
            if (equipmentState == null)
            {
                return NotFound();
            }

            _context.EquipmentStates.Remove(equipmentState);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentStateExists(Guid id)
        {
            return _context.EquipmentStates.Any(e => e.id == id);
        }
    }
}
