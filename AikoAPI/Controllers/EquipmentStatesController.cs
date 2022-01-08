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

        /// <summary>
        /// Retorna uma lista com todos os estados
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentState>>> Getequipment_state()
        {
            return await _context.equipment_state.ToListAsync();
        }

        /// <summary>
        /// Retorna o estado por meio do id
        /// </summary>
        /// <response code="200">Caso o modelo exista</response>
        /// <response code="404">Caso não encontre resultado</response>
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

        /// <summary>
        /// Retorna o estado por meio do nome (a busca é feita pelo nome exato)
        /// </summary>
        /// <response code="200">Caso o equipamento exista</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("getByName")]
        public async Task<ActionResult<EquipmentState>> GetEquipmentStateByName(String name)
        {
            var equipmentState = await _context.equipment_state.Where(e => e.Name == name)
                    .ToListAsync();

            if (equipmentState.Count == 0)
            {
                return NotFound();
            }

            return equipmentState[0];
        }

        /// <summary>
        /// Atualiza o cadastro de um estado
        /// </summary>
        /// <response code="204">Caso o objeto seja atualizado com sucesso</response>
        /// <response code="400">Caso o id do estado não seja o mesmo do payload ou outro problema nos dados informados</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentState(Guid id, EquipmentState equipmentState)
        {
            if (id != equipmentState.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentState).State = EntityState.Modified;

            if (!EquipmentStateExists(id))
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
        /// Insere um novo estado
        /// </summary>
        /// <response code="201">Caso o objeto seja inserido com sucesso</response>
        /// <response code="400">Caso haja algum problema com um dos campos do payload</response>
        /// <response code="409">Caso o objeto já exista</response>
        [HttpPost]
        public async Task<ActionResult<EquipmentState>> PostEquipmentState(EquipmentState equipmentState)
        {
            _context.equipment_state.Add(equipmentState);
            
            if (EquipmentStateExists(equipmentState.Id))
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

            return CreatedAtAction("GetEquipmentState", new { id = equipmentState.Id }, equipmentState);
        }

        /// <summary>
        /// Remove um estado
        /// </summary>
        /// <response code="204">Caso o objeto seja deletado com sucesso</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        /// <response code="500">Caso o objeto esteja relacionado à outros e não possa ser removido</response>
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
