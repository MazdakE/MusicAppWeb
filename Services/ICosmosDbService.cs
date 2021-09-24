using MusicAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppWeb.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Music>> GetItemsAsync(string query);
        //Task<Song> GetItemAsync(string id);
        Task AddItemAsync(Music music);
        //Task UpdateItemAsync(string id, Song song);
        Task DeleteItemAsync(string id);
    }
}
