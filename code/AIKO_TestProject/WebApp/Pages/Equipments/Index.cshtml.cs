using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using AIKO_TestProject.Models;
using WebApp.Services;

namespace WebApp.Pages.Equipments
{
    public class IndexModel : PageModel
    {

        public IList<AIKO_TestProject.Models.Equipment> Equipment { get;set; }

        public async Task OnGetAsync()
        {
            var client = new Client("https://localhost:44355/", new System.Net.Http.HttpClient());
            await client.EquipmentsAllAsync();
            //Equipment = await client.EquipmentsAllAsync();
        }
    }
}
