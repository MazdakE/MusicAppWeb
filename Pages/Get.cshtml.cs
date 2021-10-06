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
    public class GetModel : PageModel
    {
        private readonly ILogger<GetModel> _logger;
        private readonly ICosmosDbService _cosmosDbService;

        public GetModel(ILogger<GetModel> logger, ICosmosDbService cosmosDbService)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
        }

        [BindProperty]
        public SearchAlbum SearchTerm { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _cosmosDbService.GetItemsAsync("select * from c");
            try
            {
                var song = result.SingleOrDefault(x => x.Artist == SearchTerm.SearchTerm);
                if (song != null)
                {
                    _logger.LogInformation($"Searched for song {song.Artist}");
                    return Content("Playing: " + song.Artist + " - " + song.Title + "\n" + "id: " + song.Id);
                }

                return Content("The song you are looking for can't be found");

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Content("There is more than one " + SearchTerm.SearchTerm);
            }
        }
    }
}
