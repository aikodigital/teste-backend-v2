using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using WebApp.Services;
using WebApp.Extras;

namespace WebApp.Pages.EquipmentStateHistories
{
    public class DetailsModel : PageModel
    {
        public EquipmentStateHistory EquipmentStateHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id, string date)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentStateHistoriesGETAsync((Guid)id, DateTimeOffset.Parse(date));
            EquipmentStateHistory = result;

            if (EquipmentStateHistory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
