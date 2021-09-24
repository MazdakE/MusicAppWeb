using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppWeb.Models
{
    public class SearchAlbum
    {
        [JsonProperty(PropertyName = "searchterm")]
        public string SearchTerm { get; set; }
    }
}
