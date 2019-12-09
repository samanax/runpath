using System;
using System.Collections.Generic;

namespace runepath.Models
{
    public class PhotoAlbumsModel : AlbumModel
    {
       public List<PhotoModel> Photos { get; set; }
    }
}