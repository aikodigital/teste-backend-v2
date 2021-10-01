using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AIKO_TestProject.Context;
using AIKO_TestProject.Models;

namespace WebApp.Pages.EquipmentStates
{
    public class CreateModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentStateContext _context;

        public CreateModel(AIKO_TestProject.Context.EquipmentStateContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EquipmentState EquipmentState { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EquipmentStates.Add(EquipmentState);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
