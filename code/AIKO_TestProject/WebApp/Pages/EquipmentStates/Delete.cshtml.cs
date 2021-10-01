﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using AIKO_TestProject.Models;

namespace WebApp.Pages.EquipmentStates
{
    public class DeleteModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentStateContext _context;

        public DeleteModel(AIKO_TestProject.Context.EquipmentStateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EquipmentState EquipmentState { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipmentState = await _context.EquipmentStates.FirstOrDefaultAsync(m => m.id == id);

            if (EquipmentState == null)
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

            EquipmentState = await _context.EquipmentStates.FindAsync(id);

            if (EquipmentState != null)
            {
                _context.EquipmentStates.Remove(EquipmentState);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}