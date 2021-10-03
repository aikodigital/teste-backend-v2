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
    public class DeleteModel : PageModel
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentModelStateHourlyEarningsGETAsync(LocalID, LocalValue);
            EquipmentModelStateHourlyEarnings = result;

            if (EquipmentModelStateHourlyEarnings != null)
            {
                try
                {
                    await client.EquipmentModelStateHourlyEarningsDELETEAsync(LocalID, LocalValue);
                }
                catch (ApiException e)
                {
                    if (e.StatusCode == 500 && e.Message.Contains("violates foreign key constraint"))
                    {
                        return RedirectToPage("/Shared/ForeignKeyConstraintViolation");
                    }
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
