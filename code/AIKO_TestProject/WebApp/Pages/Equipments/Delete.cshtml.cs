using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using AIKO_TestProject.Models;

namespace WebApp.Pages.Equipments
{
    public class DeleteModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentContext _context;

        public DeleteModel(AIKO_TestProject.Context.EquipmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment = await _context.Equipments.FirstOrDefaultAsync(m => m.id == id);

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

            Equipment = await _context.Equipments.FindAsync(id);

            if (Equipment != null)
            {
                _context.Equipments.Remove(Equipment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
