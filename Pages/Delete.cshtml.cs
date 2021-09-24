using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MusicAppWeb.Models;
using MusicAppWeb.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppWeb.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        private readonly ICosmosDbService _cosmosDbService;

        public DeleteModel(ILogger<DeleteModel> logger, ICosmosDbService cosmosDbService)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
        }

        [BindProperty]
        public Music Music { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await _cosmosDbService.DeleteItemAsync(Music.Id);
            return Content("Successfully deleted");
        }
    }
}
