using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using models = AikoFrontEnd.Models;

namespace AikoFrontEnd.Pages
{
    public class EquipmentPositionHistoryPage : PageModel
    {
        public List<models.EquipmentPositionHistory> currentPositions { get; set; }
        
        private readonly ILogger<EquipmentPositionHistoryPage> _logger;

        public EquipmentPositionHistoryPage(ILogger<EquipmentPositionHistoryPage> logger)
        {
            _logger = logger;
        }

        public async Task OnGet(Guid equipmentId)
        {
            using (var client = new HttpClient())
            {
                var responseHist = await client.GetAsync(
                    "https://localhost:5001/api/EquipmentPositionHistories/currentState");
                responseHist.EnsureSuccessStatusCode();
                
                currentPositions = JsonConvert.DeserializeObject<List<models.EquipmentPositionHistory>>(responseHist.Content.ReadAsStringAsync().Result);
            }
        }
    }
}