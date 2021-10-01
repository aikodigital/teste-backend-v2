﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentContext _context;

        public DetailsModel(AIKO_TestProject.Context.EquipmentContext context)
        {
            _context = context;
        }

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
    }
}
