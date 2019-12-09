using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using runepath.Models;

namespace runepath.Services
{
    public class AlbumHttpService : IRepository<AlbumModel>
    {
        public async Task<List<AlbumModel>> Get()
        {
            List<AlbumModel> photos = new List<AlbumModel>();
            try
            {
                string url = "http://jsonplaceholder.typicode.com/albums";
                using (HttpClient client = new HttpClient())
                {
                    var content = await client.GetStringAsync(url);
                    photos = JsonConvert.DeserializeObject<List<AlbumModel>>(content);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return photos;
        }
    }
}