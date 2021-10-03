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

namespace WebApp.Pages.Equipments
{
    public class LastStateModel : PageModel
    {
        public IList<EquipmentStateLastHistory> EquipmentStateLastHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentStateLastHistoriesAsync((Guid)id);

            EquipmentStateLastHistory = result;

            if (EquipmentStateLastHistory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
