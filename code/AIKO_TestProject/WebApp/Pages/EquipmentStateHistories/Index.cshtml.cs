﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AIKO_TestProject.Context;
using WebApp.Services;
using WebApp.Extras;

namespace WebApp.Pages.EquipmentStateHistories
{
    public class IndexModel : PageModel
    {

        public IList<EquipmentStateHistory> EquipmentStateHistory { get;set; }

        public async Task OnGetAsync()
        {
            var client = new Client(Helper.APIBaseUrl, new System.Net.Http.HttpClient());
            var result = await client.EquipmentStateHistoriesAllAsync();
            EquipmentStateHistory = result;
        }
    }
}