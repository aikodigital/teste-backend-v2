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

namespace WebApp.Pages.EquipmentModelStateHourly_Earnings
{
    public class DetailsModel : PageModel
    {
        public EquipmentModelStateHourlyEarnings EquipmentModelStateHourlyEarnings { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id, float? value)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentModelStateHourlyEarningsGETAsync((Guid)id, value);
            EquipmentModelStateHourlyEarnings = result;

            if (EquipmentModelStateHourlyEarnings == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
