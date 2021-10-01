using System;
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
    public class IndexModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentStateContext _context;

        public IndexModel(AIKO_TestProject.Context.EquipmentStateContext context)
        {
            _context = context;
        }

        public IList<EquipmentState> EquipmentState { get;set; }

        public async Task OnGetAsync()
        {
            EquipmentState = await _context.EquipmentStates.ToListAsync();
        }
    }
}
