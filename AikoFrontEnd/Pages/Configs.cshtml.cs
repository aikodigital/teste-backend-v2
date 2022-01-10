using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AikoFrontEnd.Pages
{
    public class ConfigsModel : PageModel
    {
        private readonly ILogger<ConfigsModel> _logger;

        public ConfigsModel(ILogger<ConfigsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}