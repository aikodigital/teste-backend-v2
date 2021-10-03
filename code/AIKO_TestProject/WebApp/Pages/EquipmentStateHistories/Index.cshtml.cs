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
    public class IndexModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentStateHistoryContext _context;

        public IndexModel(AIKO_TestProject.Context.EquipmentStateHistoryContext context)
        {
            _context = context;
        }

        public IList<EquipmentStateHistory> EquipmentStateHistory { get;set; }

        public async Task OnGetAsync()
        {
            EquipmentStateHistory = await _context.EquipmentStateHistories.ToListAsync();
        }
    }
}
