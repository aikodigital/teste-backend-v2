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

namespace WebApp.Pages.EquipmentModels
{
    public class EditModel : PageModel
    {
        private static Guid LocalID { get; set; }
        [BindProperty]
        public EquipmentModel EquipmentModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LocalID = (Guid)id;
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentModelsGETAsync((Guid)id);
            EquipmentModel = result;

            if (EquipmentModel == null)
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


            //_context.Attach(EquipmentModel).State = EntityState.Modified;

            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentModelsGETAsync(LocalID);

            try
            {
                await client.EquipmentModelsPUTAsync(LocalID, EquipmentModel);
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
