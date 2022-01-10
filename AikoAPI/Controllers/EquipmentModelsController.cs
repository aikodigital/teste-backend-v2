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

        /// <summary>
        /// Retorna uma lista com todos os modelos de equipamento
        /// </summary>
        /// <response code="200">Caso a lista seja gerada com sucesso</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentModel>>> Getequipment_model()
        {
            return await _context.equipment_model.ToListAsync();
        }

        /// <summary>
        /// Retorna o modelo de equipamento por meio do id
        /// </summary>
        /// <response code="200">Caso o modelo exista</response>
        /// <response code="404">Caso não encontre resultado</response>
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

        /// <summary>
        /// Retorna o modelo de equipamento por meio do nome (a busca é feita pelo nome exato)
        /// </summary>
        /// <response code="200">Caso o modelo exista</response>
        /// <response code="404">Caso não encontre resultado</response>
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

        /// <summary>
        /// Atualiza o cadastro de um modelo de equipamento
        /// </summary>
        /// <response code="204">Caso o objeto seja atualizado com sucesso</response>
        /// <response code="400">Caso o id do modelo não seja o mesmo do payload ou outro problema nos dados informados</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentModel(Guid id, EquipmentModel equipmentModel)
        {
            if (id != equipmentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentModel).State = EntityState.Modified;

            if (!EquipmentModelExists(id))
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
        /// Insere um novo modelo de equipamento
        /// </summary>
        /// <response code="201">Caso o objeto seja inserido com sucesso</response>
        /// <response code="400">Caso haja algum problema com um dos campos do payload</response>
        /// <response code="409">Caso o objeto já exista</response>
        [HttpPost]
        public async Task<ActionResult<EquipmentModel>> PostEquipmentModel(EquipmentModel equipmentModel)
        {
            _context.equipment_model.Add(equipmentModel);
            
            if (EquipmentModelExists(equipmentModel.Id))
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

            return CreatedAtAction("GetEquipmentModel", new { id = equipmentModel.Id }, equipmentModel);
        }

        /// <summary>
        /// Remove um modelo de equipamento
        /// </summary>
        /// <response code="204">Caso o objeto seja deletado com sucesso</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        /// <response code="500">Caso o objeto esteja relacionado à outros e não possa ser removido</response>
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
