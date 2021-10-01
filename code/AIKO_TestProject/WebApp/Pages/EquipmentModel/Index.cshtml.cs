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
    public class IndexModel : PageModel
    {
        private readonly AIKO_TestProject.Context.EquipmentModelContext _context;

        public IndexModel(AIKO_TestProject.Context.EquipmentModelContext context)
        {
            _context = context;
        }

        public IList<Models.EquipmentModel> EquipmentModel { get;set; }

        public async Task OnGetAsync()
        {
            EquipmentModel = await _context.EquipmentModels.ToListAsync();
        }
    }
}
