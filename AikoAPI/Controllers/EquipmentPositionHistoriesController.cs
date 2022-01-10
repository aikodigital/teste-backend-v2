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
    public class EquipmentPositionHistoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipmentPositionHistoriesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma lista com as posições de um equipamento específico
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("{equipmentId}")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistory>>> GetEquipmentPositionHistory(Guid equipmentId)
        {
            var equipmentPositionHistory = await _context.equipment_position_history.Where(eph => eph.EquipmentId == equipmentId).ToListAsync();

            if (equipmentPositionHistory.Count == 0)
            {
                return NotFound();
            }

            return equipmentPositionHistory;
        }

        /// <summary>
        /// Retorna uma lista com as posições de um equipamento em uma data específica
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("byEquipmentAndDate")]
        public async Task<ActionResult<EquipmentPositionHistory>> GetEquipmentPositionHistoryByEquipmentAndDate(Guid equipmentId, String date)
        {
            var EquipmentPositionHistory = await _context.equipment_position_history.Where(eph => eph.EquipmentId == equipmentId && eph.Date == DateTime.Parse(date)).ToListAsync();

            if (EquipmentPositionHistory.Count == 0)
            {
                return NotFound();
            }

            return EquipmentPositionHistory[0];
        }

        /// <summary>
        /// Retorna uma lista com a última posição de todos os equipamentos cadastrados
        /// </summary>
        /// <response code="200">Caso haja resultados</response>
        /// <response code="404">Caso não encontre resultado</response>
        [HttpGet("currentPosition")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistory>>> GetEquipmentPositionHistoryCurrentState()
        {
            var equipmentPositionHistory = _context.equipment_position_history
                .Include(e => e.Equipment)
                .AsEnumerable()
                .GroupBy(e => e.EquipmentId)
                .Select(g => g.OrderByDescending(g => g.Date).FirstOrDefault())
                .ToList();

            if (equipmentPositionHistory.Count == 0)
            {
                return NotFound();
            }

            return equipmentPositionHistory;
        }

        /// <summary>
        /// Atualiza o cadastro de uma posição de um equipamento
        /// </summary>
        /// <response code="204">Caso o objeto seja atualizado com sucesso</response>
        /// <response code="400">Caso o id do equipamento e data informados não sejam os mesmos do payload ou outro problema nos dados informados</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpPut]
        public async Task<IActionResult> PutEquipmentPositionHistory([FromQuery] Guid equipmentId, [FromQuery] String date, EquipmentPositionHistory equipmentPositionHistory)
        {
            if (equipmentId != equipmentPositionHistory.EquipmentId || DateTime.Parse(date) != equipmentPositionHistory.Date)
            {
                return BadRequest();
            }

            _context.Entry(equipmentPositionHistory).State = EntityState.Modified;

            if (!EquipmentPositionHistoryExists(equipmentId, equipmentPositionHistory.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
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
        /// Insere uma posição de um equipamento
        /// </summary>
        /// <response code="201">Caso o objeto seja inserido com sucesso</response>
        /// <response code="400">Caso haja algum problema com um dos campos do payload</response>
        /// <response code="409">Caso o objeto já exista</response>
        /// <response code="500">Caso o equipamento informado não exista no banco de dados</response>
        [HttpPost]
        public async Task<ActionResult<EquipmentStateHistory>> PostEquipmentPositionHistory(EquipmentPositionHistory equipmentPositionHistory)
        {
            _context.equipment_position_history.Add(equipmentPositionHistory);

            if (EquipmentPositionHistoryExists(equipmentPositionHistory.EquipmentId, equipmentPositionHistory.Date.ToString("yyyy-MM-ddTHH:mm:ss")))
            {
                return Conflict();
            } else {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentPositionHistory", new { equipmentId = equipmentPositionHistory.EquipmentId, date = equipmentPositionHistory.Date }, equipmentPositionHistory);
        }

        /// <summary>
        /// Remove uma posição de equipamento
        /// </summary>
        /// <response code="204">Caso o objeto seja deletado com sucesso</response>
        /// <response code="404">Caso o objeto não seja encontrado</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteEquipmentPositionHistory([FromQuery] Guid equipmentId, [FromQuery] String date)
        {
            var equipmentPositionHistory = await _context.equipment_position_history.FindAsync(equipmentId, DateTime.Parse(date));
            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            _context.equipment_position_history.Remove(equipmentPositionHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentPositionHistoryExists(Guid id, String date)
        {
            return _context.equipment_position_history.Any(e => e.EquipmentId == id && e.Date == DateTime.Parse(date));
        }
    }
}
