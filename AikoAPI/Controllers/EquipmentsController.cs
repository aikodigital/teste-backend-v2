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
    public class EquipmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Equipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> Getequipment()
        {
            return await _context.equipment.ToListAsync();
        }

        // GET: api/Equipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(Guid id)
        {
            var equipment = await _context.equipment.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        // PUT: api/Equipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(Guid id, Equipment equipment)
        {
            if (id != equipment.id)
            {
                return BadRequest();
            }

            _context.Entry(equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
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

        // POST: api/Equipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
        {
            _context.equipment.Add(equipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipment", new { id = equipment.id }, equipment);
        }

        // DELETE: api/Equipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(Guid id)
        {
            var equipment = await _context.equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.equipment.Remove(equipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentExists(Guid id)
        {
            return _context.equipment.Any(e => e.id == id);
        }
    }
}
