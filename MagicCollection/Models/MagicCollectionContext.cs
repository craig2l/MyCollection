using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicCollection.API.Models
{
    public partial class MagicCollectionContext : DbContext
    {
        public MagicCollectionContext()
        {
        }

        public MagicCollectionContext(DbContextOptions<MagicCollectionContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<CollectionType> CollectionType { get; set; }
        public virtual DbSet<HistoricalRealizedPrice> HistoricalRealizedPrice { get; set; }
        //public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-984P5AL\\sql2014;Database=MagicCollection;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CollectionType });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AcquiredFrom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.AppraisalDate).HasColumnType("date");

                entity.Property(e => e.AppraisedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AppraisedValue).HasColumnType("money");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Author2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorSort)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Binding)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookSize)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Categories)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Category1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Condition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CopyrightHolder)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CopyrightYear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CoverImageUrl)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentLocation)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("smalldatetime");

                entity.Property(e => e.DateUpdated).HasColumnType("smalldatetime");

                entity.Property(e => e.DustJacketCondition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Edition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateSource)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedValue).HasColumnType("money");

                entity.Property(e => e.Language)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalPrice).HasColumnType("money");

                entity.Property(e => e.PrintedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PublishDate).HasColumnType("date");

                entity.Property(e => e.PublishLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Publisher)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseNum)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Series)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TitleSortBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TooleStot).HasColumnName("Toole_Stot");

                entity.Property(e => e.TotalPurchasePrice).HasColumnType("money");
            });

            modelBuilder.Entity<CollectionType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistoricalRealizedPrice>(entity =>
            {
                entity.HasIndex(e => new { e.CollectionType, e.SourceId })
                    .HasName("uc_CollectionTypeSourceId")
                    .IsUnique();

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PriceDate).HasColumnType("date");

                entity.Property(e => e.SaleLocation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.HistoricalRealizedPrice)
                    .HasForeignKey(d => new { d.SourceId, d.CollectionType })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricalRealizedPrice_Book");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });
            
        }
    }
}
