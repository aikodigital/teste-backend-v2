using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AikoFrontEnd.Models;

namespace AikoFrontEnd.Pages
{
    public class EquipmentModel : PageModel
    {
        public List<Equipment> Equipments { get; set; }
        
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
                    "https://localhost:5001/api/EquipmentModels");
                response.EnsureSuccessStatusCode();
                Console.WriteLine(response);
            }
        }
    }
}