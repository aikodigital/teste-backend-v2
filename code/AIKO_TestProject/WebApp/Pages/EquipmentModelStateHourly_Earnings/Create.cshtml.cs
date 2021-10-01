using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AIKO_TestProject.Context;
using WebApp.Services;
using WebApp.Extras;

namespace WebApp.Pages.EquipmentModelStateHourly_Earnings
{
    public class CreateModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EquipmentModelStateHourlyEarnings EquipmentModelStateHourlyEarnings { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            await client.EquipmentModelStateHourlyEarningsPOSTAsync(EquipmentModelStateHourlyEarnings);

            return RedirectToPage("./Index");
        }
    }
}
