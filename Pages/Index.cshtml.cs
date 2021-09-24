using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MusicAppWeb.Models;
using MusicAppWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICosmosDbService _cosmosDbService;

        public IndexModel(ILogger<IndexModel> logger, ICosmosDbService cosmosDbService)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
        }
        [BindProperty]
        public Music BundleMusic { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            BundleMusic.Id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddItemAsync(BundleMusic);
            return Content("WOOHOO");
        }
    }
}
