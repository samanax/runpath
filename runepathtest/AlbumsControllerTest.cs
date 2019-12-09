using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using runepath.Controllers;
using runepath.Models;
using runepathtest.Services;
using Xunit;

namespace runepathtest
{
    public class AlbumsControllerTest
    {
        private readonly AlbumsController _controller;
        private readonly AlbumFakeService _albumService;
        private readonly PhotoFakeService _photoService;

        public AlbumsControllerTest()
        {
            _albumService = new AlbumFakeService();
            _photoService = new PhotoFakeService();

            var mock = new Mock<ILogger<AlbumsController>>();
            ILogger<AlbumsController> logger = mock.Object;


            _controller = new AlbumsController(logger, _photoService, _albumService);
        }

        [Fact]
        public void Get_ReturnsOk()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<PhotoAlbumsModel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_ReturnsOk()
        {
            //Arrange 
            int id = 1;

            // Act
            var okResult = _controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ReturnsCorrectItem()
        {
            //Arrange 
            int id = 1;
            int itemCount = 2;

            // Act
            var okResult = _controller.Get(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<List<PhotoAlbumsModel>>(okResult.Value);
            Assert.Equal(itemCount, (okResult.Value as List<PhotoAlbumsModel>).Count);
        }
    }
}
