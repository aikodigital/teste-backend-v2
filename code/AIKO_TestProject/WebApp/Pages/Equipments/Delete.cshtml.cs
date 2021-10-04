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
    public class DeleteModel : PageModel
    {
        private static Guid LocalID { get; set; }
        [BindProperty]
        public Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocalID = (Guid)id;
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentsGETAsync((Guid)id);
            Equipment = result;

            if (Equipment == null)
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
            var result = await client.EquipmentsGETAsync((Guid)id);
            Equipment = result;

            if (Equipment != null)
            {
                try
                {
                    await client.EquipmentsDELETEAsync(LocalID);
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
