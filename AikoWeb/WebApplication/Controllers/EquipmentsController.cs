using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Generics;
using WebApplication.Models;
using WebApplication.Models.ViewModel;

namespace WebApplication.Controllers
{
    public class EquipmentsController : Controller
    {
        public IActionResult Index()
        {
            var _request = new ApiRequest(new HttpClient());
            var responseContent = _request.GetAsync("equipment").Result;
            var model = JsonConvert.DeserializeObject<List<Equipment>>(responseContent);
            return View(new LayoutViewModel<EquipmentViewModel>(new EquipmentViewModel
            {
                Equipments = model
            }));
        }
        
    }
}