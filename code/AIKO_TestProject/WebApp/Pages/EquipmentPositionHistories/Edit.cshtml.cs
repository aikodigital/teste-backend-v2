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

namespace WebApp.Pages.EquipmentPositionHistories
{
    public class EditModel : PageModel
    {
        private static Guid LocalID { get; set; }
        private static string LocalDate { get; set; }

        [BindProperty]
        public EquipmentPositionHistory EquipmentPositionHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id, string date)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocalID = (Guid)id;
            LocalDate = date;
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentPositionHistoriesGETAsync((Guid)id, DateTimeOffset.Parse(date));
            EquipmentPositionHistory = result;

            if (EquipmentPositionHistory == null)
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
            var result = await client.EquipmentPositionHistoriesGETAsync(LocalID, DateTimeOffset.Parse(LocalDate));

            try
            {
                await client.EquipmentPositionHistoriesPUTAsync(LocalID, DateTimeOffset.Parse(LocalDate), EquipmentPositionHistory);
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
