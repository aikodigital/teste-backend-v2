using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using WebApp.Services;
using WebApp.Extras;

namespace WebApp.Pages.EquipmentModelStateHourly_Earnings
{
    public class EditModel : PageModel
    {
        private static Guid LocalID { get; set; }
        private static Single? LocalValue { get; set; }
        [BindProperty]
        public EquipmentModelStateHourlyEarnings EquipmentModelStateHourlyEarnings { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id, Single? value)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocalID = (Guid)id;
            LocalValue = value;
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentModelStateHourlyEarningsGETAsync((Guid)id, value);
            EquipmentModelStateHourlyEarnings = result;

            if (EquipmentModelStateHourlyEarnings == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentModelStateHourlyEarningsGETAsync(LocalID, LocalValue);

            try
            {
                await client.EquipmentModelStateHourlyEarningsPUTAsync(LocalID, LocalValue, EquipmentModelStateHourlyEarnings);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToPage("./Index");
        }

    }
}
