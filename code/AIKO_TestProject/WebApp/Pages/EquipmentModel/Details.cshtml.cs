using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using AIKO_TestProject.Models;

namespace WebApp.Pages.EquipmentModel
{
    public class DetailsModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentModelContext _context;

        public DetailsModel(AIKO_TestProject.Context.EquipmentModelContext context)
        {
            _context = context;
        }

        public EquipmentModel EquipmentModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipmentModel = await _context.EquipmentModels.FirstOrDefaultAsync(m => m.id == id);

            if (EquipmentModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
