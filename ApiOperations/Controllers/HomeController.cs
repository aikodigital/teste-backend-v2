using ApiOperations.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOperations.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly IEquipmentRepository _equipment;
        private readonly IStateHistoryRepository _stateHistory;
        private readonly IPositionHistoryRepository _positionHistory;

        public HomeController(IEquipmentRepository equipment, IStateHistoryRepository stateHistory, IPositionHistoryRepository positionHistory)
        {
            _equipment = equipment;
            _stateHistory = stateHistory;
            _positionHistory = positionHistory;
        }

        [HttpGet]
        public IActionResult Equipments()
        {
            ViewBag.Equipments = _equipment.GetEquipmentsView();
            return View();
        }

        [HttpGet("ViewPositions/{name}")]
        public IActionResult ViewPositions(string name)
        {
            ViewBag.Histories = _positionHistory.GetPositionHistories(name);
            return View();
        }

        [HttpGet("ViewStates/{name}")]
        public IActionResult ViewStates(string name)
        {
            ViewBag.Histories = _stateHistory.GetStateHistories(name);
            return View();
        }
    }
}
