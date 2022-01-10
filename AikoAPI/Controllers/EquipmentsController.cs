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

        /// <summary>
        /// Retorna uma lista com todos os equipamentos
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> Getequipment()
        {
            return await _context.equipment.Include(e => e.EquipmentModel).ToListAsync();
        }

        /// <summary>
        /// Retorna o equipamento por meio do id
        /// </summary>
        /// <response code="200">Caso o modelo exista</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipmentById(Guid id)
        {
            var equipment = await _context.equipment.Include(e => e.EquipmentModel).FirstOrDefaultAsync();

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }
        
        /// <summary>
        /// Retorna o equipamento por meio do nome (a busca é feita pelo nome exato)
        /// </summary>
        /// <response code="200">Caso o equipamento exista</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("getByName")]
        public async Task<ActionResult<Equipment>> GetEquipmentByName([FromQuery] string name)
        {
            var equipments = await _context.equipment
                    .Include(e => e.EquipmentModel)
                    .Where(e => e.Name == name)
                    .ToListAsync();

            if (equipments.Count == 0)
            {
                return NotFound();
            }

            return equipments[0];
        }

        /// <summary>
        /// Atualiza o cadastro de um equipamento
        /// </summary>
        /// <response code="204">Caso o objeto seja atualizado com sucesso</response>
        /// <response code="400">Caso o id do equipamento não seja o mesmo do payload ou outro problema nos dados informados</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(Guid id, Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipment).State = EntityState.Modified;

            if (!EquipmentExists(id))
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {        
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Insere um novo equipamento
        /// </summary>
        /// <response code="201">Caso o objeto seja inserido com sucesso</response>
        /// <response code="400">Caso haja algum problema com um dos campos do payload</response>
        /// <response code="409">Caso o objeto já exista</response>
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
        {
            _context.equipment.Add(equipment);
            
            if (EquipmentExists(equipment.Id))
            {
                return Conflict();
            }
            else
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {    
                    throw;
                }
            }

            return CreatedAtAction("GetEquipment", new { id = equipment.Id }, equipment);
        }

        /// <summary>
        /// Remove um equipamento
        /// </summary>
        /// <response code="204">Caso o objeto seja deletado com sucesso</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        /// <response code="500">Caso o objeto esteja relacionado à outros e não possa ser removido</response>
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
            return _context.equipment.Any(e => e.Id == id);
        }
    }
}
