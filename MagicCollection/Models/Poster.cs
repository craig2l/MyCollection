using MagicCollection.API.Models;
using System;
using System.Collections.Generic;

namespace MagicCollection.API
{
    public partial class Poster
    {
        public Poster()
        {
            Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }
        public string CollectionType { get; set; }
        public string Title { get; set; }
        public string SecondaryText { get; set; }
        public double? SizeHeight { get; set; }
        public double? SizeWidth { get; set; }
        public string SizeUnits { get; set; }
        public string FeaturedSubject { get; set; }
        public string SubjectTheme { get; set; }
        public string CopyrightYear { get; set; }
        public string PrintedBy { get; set; }
        public string Edition { get; set; }
        public string Condition { get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public string AcquiredFrom { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Language { get; set; }
        public decimal? EstimatedValue { get; set; }
        public string EstimateSource { get; set; }
        public DateTime? EstimateDate { get; set; }
        public string EstimateReliability { get; set; }
        public string EstimateNotes { get; set; }
        public bool? Appraised { get; set; }
        public decimal? AppraisedValue { get; set; }
        public DateTime? AppraisalDate { get; set; }
        public string AppraisedBy { get; set; }
        public string AppraisalNotes { get; set; }
        public string Comments { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
        public string CurrentLocation { get; set; }
        public string InventoryId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
