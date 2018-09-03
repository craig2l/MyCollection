using System;
using System.Collections.Generic;

namespace MagicCollection.API.Models
{
    public partial class HistoricalRealizedPrice
    {
        public int Id { get; set; }
        public string CollectionType { get; set; }
        public int SourceId { get; set; }
        public decimal Price { get; set; }
        public DateTime? PriceDate { get; set; }
        public string SaleLocation { get; set; }
        public string Notes { get; set; }

        public Book Book { get; set; }
    }
}
