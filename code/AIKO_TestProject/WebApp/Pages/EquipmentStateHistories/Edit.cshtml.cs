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

namespace WebApp.Pages.EquipmentStateHistories
{
    public class EditModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentStateHistoryContext _context;

        public EditModel(AIKO_TestProject.Context.EquipmentStateHistoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EquipmentStateHistory EquipmentStateHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipmentStateHistory = await _context.EquipmentStateHistories.FirstOrDefaultAsync(m => m.equipment_id == id);

            if (EquipmentStateHistory == null)
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

            _context.Attach(EquipmentStateHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentStateHistoryExists(EquipmentStateHistory.equipment_id))
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

        private bool EquipmentStateHistoryExists(Guid id)
        {
            return _context.EquipmentStateHistories.Any(e => e.equipment_id == id);
        }
    }
}
