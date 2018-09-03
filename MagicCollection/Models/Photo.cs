using System;
using System.Collections.Generic;

namespace MagicCollection.API.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public string CollectionType { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool? IsPrimary { get; set; }
        public DateTime DateCreated { get; set; }

        public Book Book { get; set; }   
        public int BookId { get; set; }
        public Poster Poster { get; set; }
        public int PosterId { get; set; }
    }
}
