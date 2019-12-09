using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using runepath.Models;
using runepath.Services;

namespace runepathtest.Services
{
    public class PhotoFakeService : IRepository<PhotoModel>
    {
        private readonly List<PhotoModel> _photos;
        public PhotoFakeService()
        {
            _photos = new List<PhotoModel>()
            {
                new PhotoModel(){ Id = 1, AlbumId = 1, Title = "accusamus beatae ad facilis cum similique qui sunt", ThumbnailUrl= "https://via.placeholder.com/600/92c952", Url= "https://via.placeholder.com/150/92c952"},
                new PhotoModel(){ Id = 2, AlbumId = 1, Title = "reprehenderit est deserunt velit ipsam", ThumbnailUrl= "https://via.placeholder.com/600/771796", Url= "https://via.placeholder.com/150/771796"},
                new PhotoModel(){ Id = 3, AlbumId = 1, Title = "officia porro iure quia iusto qui ipsa ut modi", ThumbnailUrl= "https://via.placeholder.com/600/24f355", Url= "https://via.placeholder.com/150/24f355"},
                new PhotoModel(){ Id = 52, AlbumId = 2, Title = "non sunt voluptatem placeat consequuntur rem incidunt", ThumbnailUrl= "https://via.placeholder.com/600/8e973b", Url= "https://via.placeholder.com/150/8e973b"},
            };
        }

        public async Task<List<PhotoModel>> Get()
        {
            return _photos;
        }
    }
}