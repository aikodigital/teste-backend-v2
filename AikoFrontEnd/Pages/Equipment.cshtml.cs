using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using models = AikoFrontEnd.Models;

namespace AikoFrontEnd.Pages
{
    public class EquipmentModel : PageModel
    {
        public List<models.Equipment> Equipments { get; set; }
        
        private readonly ILogger<EquipmentModel> _logger;

        public EquipmentModel(ILogger<EquipmentModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(
                    "https://localhost:5001/api/Equipments");
                response.EnsureSuccessStatusCode();
                Equipments = JsonSerializer.Deserialize<List<models.Equipment>>(response.Content.ReadAsStringAsync().Result);
            }
        }
        
        public async Task OnPost()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(
                    "https://localhost:5001/api/Equipments");
                response.EnsureSuccessStatusCode();
                Equipments = JsonSerializer.Deserialize<List<models.Equipment>>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}