using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicCollection.API.Dto
{
    public class PhotosDto
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public string CollectionType { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool? IsPrimary { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
