using MagicCollection.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicCollection.API.Dto
{
    public class BookLite
    {
        public int Id { get; set; }
        public string CollectionType { get; set; }
        public string Title { get; set; }
        public string TitleSortBy { get; set; }
        public string Authors { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotosDto> Photos { get; set; }
    }
}
