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
    public class EquipmentPositionLastHistoriesController : ControllerBase
    {
        private readonly EquipmentPositionLastHistoryContext _context;

        public EquipmentPositionLastHistoriesController(EquipmentPositionLastHistoryContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentPositionLastHistories/5
        [HttpGet("{id}")]
        public async Task<List<EquipmentPositionLastHistory>> GetEquipmentPositionLastHistory_ByID(Guid id)
        {
            var equipmentPositionLastHistory = await Task.Run(() =>


            _context.EquipmentPositionLastHistories.FromSqlRaw(@"SELECT EPH.date, EPH.lat as equipment_position_lat, EPH.lon as equipment_position_lon,
                                                            E.id as equipment_id, E.name as equipment_name, EM.id equipment_model_id, EM.id equipment_model_name
                                                            FROM operation.equipment_position_history AS EPH
                                                            FULL JOIN operation.equipment AS E ON E.id = EPH.equipment_id
                                                            FULL JOIN operation.equipment_model AS EM ON EM.id = E.equipment_model_id
                                                            WHERE EPH.equipment_id = {0}
                                                            AND EPH.date = (SELECT MAX(date)
                                                            FROM operation.equipment_position_history
                                                            WHERE equipment_id = {0})", id).ToListAsync()

            );
            //var equipmentPositionLastHistory = await _context.EquipmentPositionLastHistories.FindAsync(id);

            if (equipmentPositionLastHistory == null)
            {
                return null;
            }

            return equipmentPositionLastHistory;
        }

        

    }
}
