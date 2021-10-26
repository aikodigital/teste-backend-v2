using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Generics;
using WebApplication.Models;
using WebApplication.Models.ViewModel;

namespace WebApplication.Controllers
{
    public class StateController : Controller
    {
        public IActionResult EquipmentStateHistory()
        {
            var _request = new ApiRequest(new HttpClient());
            var responseContent = _request.GetAsync("EquipmentStateHistory").Result;
            var model = JsonConvert.DeserializeObject<List<EquipmentStateHistory>>(responseContent);
            return View(new LayoutViewModel<EquipmentStateHistoryViewModel>(new EquipmentStateHistoryViewModel
            {
                EquipmentHistories = model
            }));
        }
    }
}