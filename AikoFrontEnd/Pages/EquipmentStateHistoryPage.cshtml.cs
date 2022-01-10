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
    public class EquipmentStateHistoryPage : PageModel
    {
        public List<models.EquipmentState> states { get; set; }
        public List<models.EquipmentStateHistory> currentStates { get; set; }
        public List<models.EquipmentStateHistory> equipmentHistory { get; set; }
        
        private readonly ILogger<EquipmentStateHistoryPage> _logger;

        public EquipmentStateHistoryPage(ILogger<EquipmentStateHistoryPage> logger)
        {
            _logger = logger;
        }

        public async Task OnGet(Guid equipmentId)
        {
            using (var client = new HttpClient())
            {
                var responseStates = await client.GetAsync(
                    "https://localhost:5001/api/EquipmentStates");
                responseStates.EnsureSuccessStatusCode();
                states = JsonConvert.DeserializeObject<List<models.EquipmentState>>(responseStates.Content.ReadAsStringAsync().Result);

                var responseHist = await client.GetAsync(
                    "https://localhost:5001/api/EquipmentStateHistories/currentState");
                responseHist.EnsureSuccessStatusCode();
                
                currentStates = JsonConvert.DeserializeObject<List<models.EquipmentStateHistory>>(responseHist.Content.ReadAsStringAsync().Result);

                if (equipmentId != Guid.Empty)
                {
                    Console.WriteLine(equipmentId);
                    var responseHistComplete = await client.GetAsync(
                        $"https://localhost:5001/api/EquipmentStateHistories/{equipmentId}");
                    responseHistComplete.EnsureSuccessStatusCode();
                    equipmentHistory = JsonConvert.DeserializeObject<List<models.EquipmentStateHistory>>(responseHistComplete.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public IActionResult OnPostEquip(Guid equipmentId)
        {
            return RedirectToPage("EquipmentStateHistoryPage", equipmentId);
            
        }
    }
}