using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using runepath.Models;

namespace runepath.Services
{
    public class PhotoHttpService : IRepository<PhotoModel>
    {
        public async Task<List<PhotoModel>> Get()
        {
            List<PhotoModel> photos = new List<PhotoModel>();
            try
            {
                string url = "http://jsonplaceholder.typicode.com/photos";
                using (HttpClient client = new HttpClient())
                {
                    var content = await client.GetStringAsync(url);
                    photos = JsonConvert.DeserializeObject<List<PhotoModel>>(content);
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