using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using AIKO_TestProject.Models;

namespace WebApp.Pages.EquipmentStateHistories
{
    public class DeleteModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentStateHistoryContext _context;

        public DeleteModel(AIKO_TestProject.Context.EquipmentStateHistoryContext context)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipmentStateHistory = await _context.EquipmentStateHistories.FindAsync(id);

            if (EquipmentStateHistory != null)
            {
                _context.EquipmentStateHistories.Remove(EquipmentStateHistory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
