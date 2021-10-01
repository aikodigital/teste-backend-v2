using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using AIKO_TestProject.Models;

namespace WebApp.Pages.EquipmentModels
{
    public class EditModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentModelContext _context;

        public EditModel(AIKO_TestProject.Context.EquipmentModelContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EquipmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentModelExists(EquipmentModel.id))
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

        private bool EquipmentModelExists(Guid id)
        {
            return _context.EquipmentModels.Any(e => e.id == id);
        }
    }
}
