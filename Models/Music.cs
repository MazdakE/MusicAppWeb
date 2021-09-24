using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppWeb.Models
{
    public class Music
    {
        [JsonProperty(PropertyName = "id")]
        [Display(Name = "Song Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "artist")]
        [Display(Name = "Artist name")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "title")]
        [Display(Name = "Name of song")]
        public string Title { get; set; }
    }
}
