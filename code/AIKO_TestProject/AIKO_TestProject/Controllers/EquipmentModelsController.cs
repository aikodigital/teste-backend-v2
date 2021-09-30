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
    public class EquipmentModelsController : ControllerBase
    {
        private readonly EquipmentModelContext _context;

        public EquipmentModelsController(EquipmentModelContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentModel>>> GetEquipmentModels()
        {
            return await _context.EquipmentModels.ToListAsync();
        }

        // GET: api/EquipmentModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentModel>> GetEquipmentModel(Guid id)
        {
            var equipmentModel = await _context.EquipmentModels.FindAsync(id);

            if (equipmentModel == null)
            {
                return NotFound();
            }

            return equipmentModel;
        }

        // PUT: api/EquipmentModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentModel(Guid id, EquipmentModel equipmentModel)
        {
            if (id != equipmentModel.id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentModelExists(id))
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

        // POST: api/EquipmentModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentModel>> PostEquipmentModel(EquipmentModel equipmentModel)
        {
            _context.EquipmentModels.Add(equipmentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentModel", new { id = equipmentModel.id }, equipmentModel);
        }

        // DELETE: api/EquipmentModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentModel(Guid id)
        {
            var equipmentModel = await _context.EquipmentModels.FindAsync(id);
            if (equipmentModel == null)
            {
                return NotFound();
            }

            _context.EquipmentModels.Remove(equipmentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentModelExists(Guid id)
        {
            return _context.EquipmentModels.Any(e => e.id == id);
        }
    }
}
