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
    public class EquipmentModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentModel>>> Getequipment_model()
        {
            return await _context.equipment_model.ToListAsync();
        }

        // GET: api/EquipmentModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentModel>> GetEquipmentModel(Guid id)
        {
            var equipmentModel = await _context.equipment_model.FindAsync(id);

            if (equipmentModel == null)
            {
                return NotFound();
            }

            return equipmentModel;
        }
                
        [HttpGet("getByName")]
        public async Task<ActionResult<EquipmentModel>> GetEquipmentModelByName([FromQuery] string name)
        {
            var equipmentModels = await _context.equipment_model.Where(e => e.Name == name)
                    .ToListAsync();

            if (equipmentModels.Count == 0)
            {
                return NotFound();
            }

            return equipmentModels[0];
        }

        // PUT: api/EquipmentModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentModel(Guid id, EquipmentModel equipmentModel)
        {
            if (id != equipmentModel.Id)
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
            _context.equipment_model.Add(equipmentModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentModelExists(equipmentModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentModel", new { id = equipmentModel.Id }, equipmentModel);
        }

        // DELETE: api/EquipmentModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentModel(Guid id)
        {
            var equipmentModel = await _context.equipment_model.FindAsync(id);
            if (equipmentModel == null)
            {
                return NotFound();
            }

            _context.equipment_model.Remove(equipmentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentModelExists(Guid id)
        {
            return _context.equipment_model.Any(e => e.Id == id);
        }
    }
}
