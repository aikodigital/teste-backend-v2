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

namespace WebApp.Pages.EquipmentPositionHistories
{
    public class DeleteModel : PageModel
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentPositionHistoriesGETAsync(LocalID, DateTimeOffset.Parse(LocalDate));
            EquipmentPositionHistory = result;

            if (EquipmentPositionHistory != null)
            {
                try
                {
                    await client.EquipmentPositionHistoriesDELETEAsync(LocalID, DateTimeOffset.Parse(LocalDate));
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
