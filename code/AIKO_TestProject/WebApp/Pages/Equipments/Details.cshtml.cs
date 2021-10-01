using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using WebApp.Services;

namespace WebApp.Pages.Equipments
{
    public class DetailsModel : PageModel
    {

        public Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new Client("https://localhost:44355/", new System.Net.Http.HttpClient());
            var result = await client.EquipmentsGETAsync((Guid)id);
            Equipment = result;

            if (Equipment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
