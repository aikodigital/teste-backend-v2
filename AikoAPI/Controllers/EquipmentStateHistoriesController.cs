using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AikoAPI;
using AikoAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AikoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentStateHistoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentStateHistoriesController(AppDbContext context)
        {
            _context = context;
        }
                
        /// <summary>
        /// Retorna uma lista com os estados de um equipamento específico
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("{equipmentId}")]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistory>>> GetEquipmentStateHistory(Guid equipmentId)
        {
            var equipmentStateHistory = await _context.equipment_state_history.Include(e => e.Equipment).Where(esh => esh.EquipmentId == equipmentId).ToListAsync();

            if (equipmentStateHistory == null)
            {
                return NotFound();
            }

            return equipmentStateHistory;
        }

        /// <summary>
        /// Retorna uma lista com os estados de um equipamento em uma data específica
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("byEquipmentAndDate")]
        public async Task<ActionResult<EquipmentStateHistory>> GetEquipmentStateHistoryByEquipmentAndDate(Guid equipmentId, String date)
        {
            var equipmentStateHistory = await _context.equipment_state_history.Where(esh => esh.EquipmentId == equipmentId && esh.Date == DateTime.Parse(date)).ToListAsync();

            if (equipmentStateHistory.Count == 0)
            {
                return NotFound();
            }

            return equipmentStateHistory[0];
        }

        /// <summary>
        /// Retorna uma lista com o último estado de todos os equipamentos cadastrados
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("currentState")]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistory>>> GetEquipmentStateHistoryCurrentState()
        {
            var equipmentStateHistory = _context.equipment_state_history
                .Include(e => e.Equipment)
                .AsEnumerable()
                .GroupBy(e => e.EquipmentId)
                .Select(g => g.OrderByDescending(g => g.Date).FirstOrDefault())
                .ToList();

            if (equipmentStateHistory.Count == 0)
            {
                return NotFound();
            }

            return equipmentStateHistory;
        }

        /// <summary>
        /// Atualiza o cadastro de um estado de um equipamento
        /// </summary>
        /// <response code="204">Caso o objeto seja atualizado com sucesso</response>
        /// <response code="400">Caso o id do equipamento e data informados não sejam os mesmos do payload ou outro problema nos dados informados</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpPut]
        public async Task<IActionResult> PutEquipmentStateHistory([FromQuery] Guid equipmentId, [FromQuery] String date, EquipmentStateHistory equipmentStateHistory)
        { 
            if (equipmentId != equipmentStateHistory.EquipmentId || DateTime.Parse(date) != equipmentStateHistory.Date)
            {
                return BadRequest();
            }

            _context.Entry(equipmentStateHistory).State = EntityState.Modified;
            
            if (!EquipmentStateHistoryExists(equipmentId, equipmentStateHistory.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
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
        /// Insere um estado de um equipamento
        /// </summary>
        /// <response code="201">Caso o objeto seja inserido com sucesso</response>
        /// <response code="400">Caso haja algum problema com um dos campos do payload</response>
        /// <response code="409">Caso o objeto já exista</response>
        /// <response code="500">Caso o equipamento informado não exista no banco de dados</response>
        [HttpPost]
        public async Task<ActionResult<EquipmentStateHistory>> PostEquipmentStateHistory(EquipmentStateHistory equipmentStateHistory)
        {
            _context.equipment_state_history.Add(equipmentStateHistory);
            
            if (EquipmentStateHistoryExists(equipmentStateHistory.EquipmentId, equipmentStateHistory.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
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

            return CreatedAtAction("GetEquipmentStateHistory", new { equipmentId = equipmentStateHistory.EquipmentId, date = equipmentStateHistory.Date }, equipmentStateHistory);
        }

        /// <summary>
        /// Remove um estado de equipamento
        /// </summary>
        /// <response code="204">Caso o objeto seja deletado com sucesso</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteEquipmentStateHistory([FromQuery] Guid equipmentId, [FromQuery] String date)
        {
            var equipmentStateHistory = await _context.equipment_state_history.FindAsync(equipmentId, DateTime.Parse(date));
            if (equipmentStateHistory == null)
            {
                return NotFound();
            }

            _context.equipment_state_history.Remove(equipmentStateHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentStateHistoryExists(Guid id, String date)
        {
            return _context.equipment_state_history.Any(e => e.EquipmentId == id && e.Date == DateTime.Parse(date));
        }
    }
}
