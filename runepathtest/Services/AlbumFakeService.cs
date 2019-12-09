using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using runepath.Models;
using runepath.Services;

namespace runepathtest.Services
{
    public class AlbumFakeService : IRepository<AlbumModel>
    {
        private readonly List<AlbumModel> _albums;
        public AlbumFakeService()
        {
            _albums = new List<AlbumModel>()
            {
                new AlbumModel(){ Id = 1,Title = "quidem molestiae enim", UserId=1},
                new AlbumModel(){ Id = 2,Title = "sunt qui excepturi placeat culpa", UserId=1},
                new AlbumModel(){ Id = 3,Title = "omnis laborum odio", UserId=2},
            };
        }

        public async Task<List<AlbumModel>> Get()
        {
            return _albums;
        }
    }
}