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
    public class EquipmentStateLastHistoriesController : ControllerBase
    {
        private readonly EquipmentStateLastHistoryContext _context;

        public EquipmentStateLastHistoriesController(EquipmentStateLastHistoryContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentStateLastHistories/5
        [HttpGet("{id}")]
        public async Task<List<EquipmentStateLastHistory>> GetEquipmentStateLastHistory_ByID(Guid id)
        {
            var equipmentStateLastHistory = await Task.Run(() =>


            _context.EquipmentStateLastHistories.FromSqlRaw(@"SELECT ESH.date, ES.id as equipment_state_id, ES.name as equipment_state_name, 
                                                                    ES.color AS equipment_state_color,
                                                                    E.id as equipment_id, E.name as equipment_name, EM.id as equipment_model_id,
                                                                    EM.name as equipment_model_name
                                                                    FROM operation.equipment_state_history as ESH
                                                                    FULL JOIN operation.equipment_state AS ES ON ES.id = ESH.equipment_state_id
                                                                    FULL JOIN operation.equipment AS E ON E.id = ESH.equipment_id
                                                                    FULL JOIN operation.equipment_model AS EM ON EM.id = E.equipment_model_id
                                                                    WHERE ESH.equipment_id = {0}
                                                                    AND ESH.date = (SELECT MAX(date)
                                                                                    FROM operation.equipment_state_history
                                                                                    WHERE equipment_id = {0})", id).ToListAsync()

            );

            if (equipmentStateLastHistory == null)
            {
                return null;
            }

            return equipmentStateLastHistory;
        }

        // GET: api/EquipmentStateLastHistories/5
        [HttpGet("all/{id}")]
        public async Task<List<EquipmentStateLastHistory>> GetEquipmentStateLastHistory_All(Guid id)
        {
            var equipmentStateLastHistory = await Task.Run(() =>


            _context.EquipmentStateLastHistories.FromSqlRaw(@"SELECT ESH.date, ES.id as equipment_state_id, ES.name as equipment_state_name, 
                                                                    ES.color AS equipment_state_color,
                                                                    E.id as equipment_id, E.name as equipment_name, EM.id as equipment_model_id,
                                                                    EM.name as equipment_model_name
                                                                    FROM operation.equipment_state_history as ESH
                                                                    FULL JOIN operation.equipment_state AS ES ON ES.id = ESH.equipment_state_id
                                                                    FULL JOIN operation.equipment AS E ON E.id = ESH.equipment_id
                                                                    FULL JOIN operation.equipment_model AS EM ON EM.id = E.equipment_model_id
                                                                    WHERE ESH.equipment_id = {0}", id).ToListAsync()

            );

            if (equipmentStateLastHistory == null)
            {
                return null;
            }

            return equipmentStateLastHistory;
        }

    }
}
