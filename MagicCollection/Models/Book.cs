﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicCollection.API.Models
{
    [Table("Book")]
    public partial class Book
    {
        public Book()
        {
            HistoricalRealizedPrice = new HashSet<HistoricalRealizedPrice>();
        }

        public int Id { get; set; }
        public short CollectionType { get; set; }
        public string Title { get; set; }
        public string TitleSortBy { get; set; }
        public string Author { get; set; }
        public string Author2 { get; set; }
        public string AuthorSort { get; set; }
        public short? BookFormat { get; set; }
        public short? SubjectTheme { get; set; }
        public string CopyrightYear { get; set; }
        public string CopyrightHolder { get; set; }
        public string Publisher { get; set; }
        public DateTime? PublishDate { get; set; }
        public string PublishLocation { get; set; }
        public string Edition { get; set; }
        public string Condition { get; set; }
        public decimal? TotalPurchasePrice { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string Binding { get; set; }
        public bool? HasDustJacket { get; set; }
        public string DustJacketCondition { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public string AcquiredFrom { get; set; }
        public string PrintedBy { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Language { get; set; }
        public string Series { get; set; }
        public string ReleaseNum { get; set; }
        public int? NumberPages { get; set; }
        public string BookSize { get; set; }
        public decimal? EstimatedValue { get; set; }
        public string EstimateSource { get; set; }
        public byte? EstimateReliability { get; set; }
        public bool? Appraised { get; set; }
        public decimal? AppraisedValue { get; set; }
        public DateTime? AppraisalDate { get; set; }
        public string AppraisedBy { get; set; }
        public string Comments { get; set; }
        public short? TooleStot { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Categories { get; set; }
        public string CurrentLocation { get; set; }
        public string CoverImageUrl { get; set; }
        public int? BookReferenceId { get; set; }
        public int? InventoryNumber { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<HistoricalRealizedPrice> HistoricalRealizedPrice { get; set; }
    }
}