using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using runepath.Models;
using runepath.Services;
using Microsoft.Extensions.Caching.Memory;

namespace runepath.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly ILogger<AlbumsController> _logger;

        private readonly MemoryCacheEntryOptions cacheEntryOptions;
        private readonly IRepository<PhotoModel> _photoService;
        private readonly IRepository<AlbumModel> _albumService;
        private string photoCacheKey = "Photos";
        private string albumCacheKey = "Albums";


        public AlbumsController(ILogger<AlbumsController> logger, IRepository<PhotoModel> photoService,
                                IRepository<AlbumModel> albumService)
        {
            _logger = logger;
            _photoService = photoService;
            _albumService = albumService;
            // Set cache options.
            cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            List<PhotoAlbumsModel> results;
            try
            {
                results = await GetMergedData();
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in controller: {exp.StackTrace}");
                return StatusCode(500);
            }
            return Ok(results);
        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> Get(int userid)
        {
            List<PhotoAlbumsModel> results;
            try
            {
                if (userid > 0)
                {
                    results = (await GetMergedData()).Where(u => u.UserId.Equals(userid)).ToList();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in controller: {exp.StackTrace}");
                return StatusCode(500);
            }
            return Ok(results);
        }
        private async Task<List<AlbumModel>> FetchAlbums()
        {
            List<AlbumModel> albums;
            try
            {
               
                    albums = await _albumService.Get();
                  
            }
            catch (Exception)
            {
                throw;
            }
            return albums;
        }

        private async Task<List<PhotoModel>> FetchPhotos()
        {
            List<PhotoModel> photos;
            try
            {
                    photos = await _photoService.Get();
            }
            catch (Exception)
            {
                throw;
            }
            return photos;
        }
        private async Task<List<PhotoAlbumsModel>> GetMergedData()
        {
            List<PhotoAlbumsModel> results = new List<PhotoAlbumsModel>();
            try
            {
                List<PhotoModel> photos = await FetchPhotos();
                List<AlbumModel> albums = await FetchAlbums();
                foreach (AlbumModel album in albums)
                {
                    PhotoAlbumsModel newPhotoAlbum = new PhotoAlbumsModel() { Id = album.Id, Title = album.Title, UserId = album.UserId };
                    newPhotoAlbum.Photos = photos.Where(p => p.AlbumId.Equals(album.Id)).ToList();
                    results.Add(newPhotoAlbum);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return results;
        }


    }
}
