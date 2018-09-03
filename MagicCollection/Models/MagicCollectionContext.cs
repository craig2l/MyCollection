using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CollectionType> CollectionTypes { get; set; }
        public virtual DbSet<CollectionUser> CollectionUsers { get; set; }
        public virtual DbSet<HistoricalRealizedPrice> HistoricalRealizedPrices { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Poster> Posters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CollectionType });

                entity.ToTable("Book");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CollectionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AcquiredFrom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.AppraisalDate).HasColumnType("date");

                entity.Property(e => e.AppraisalNotes).IsUnicode(false);

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

                entity.Property(e => e.BookFormat)
                    .HasMaxLength(50)
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

                entity.Property(e => e.CurrentLocation)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("smalldatetime");

                entity.Property(e => e.DateUpdated).HasColumnType("smalldatetime");

                entity.Property(e => e.DustJacketCondition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Edition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateNotes).IsUnicode(false);

                entity.Property(e => e.EstimateReliability)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateSource)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedValue).HasColumnType("money");

                entity.Property(e => e.InventoryNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

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

                entity.Property(e => e.SubjectTheme)
                    .HasMaxLength(50)
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

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CollectionType>(entity =>
            {
                entity.ToTable("CollectionType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CollectionUser>(entity =>
            {
                entity.ToTable("CollectionUser");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistoricalRealizedPrice>(entity =>
            {
                entity.ToTable("HistoricalRealizedPrice");

                entity.HasIndex(e => new { e.CollectionType, e.SourceId })
                    .HasName("uc_CollectionTypeSourceId")
                    .IsUnique();

                entity.Property(e => e.CollectionType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PriceDate).HasColumnType("date");

                entity.Property(e => e.SaleLocation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.HistoricalRealizedPrices)
                    .HasForeignKey(d => new { d.SourceId, d.CollectionType })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricalRealizedPrice_Books");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");

                entity.Property(e => e.CollectionType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => new { d.SourceId, d.CollectionType })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Book_SourceIdCollectionType");

                entity.HasOne(d => d.Poster)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => new { d.SourceId, d.CollectionType })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Poster_SourceIdCollectionType");
            });

            modelBuilder.Entity<Poster>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CollectionType });

                entity.ToTable("Poster");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CollectionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AcquiredFrom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.AppraisalDate).HasColumnType("date");

                entity.Property(e => e.AppraisalNotes).IsUnicode(false);

                entity.Property(e => e.AppraisedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppraisedValue).HasColumnType("money");

                entity.Property(e => e.Category1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Condition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CopyrightYear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentLocation)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("smalldatetime");

                entity.Property(e => e.DateUpdated).HasColumnType("smalldatetime");

                entity.Property(e => e.Edition)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateDate).HasColumnType("date");

                entity.Property(e => e.EstimateNotes).IsUnicode(false);

                entity.Property(e => e.EstimateReliability)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateSource)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedValue).HasColumnType("money");

                entity.Property(e => e.FeaturedSubject)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InventoryId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrintedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PurchasePrice).HasColumnType("money");

                entity.Property(e => e.SecondaryText)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SizeUnits)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectTheme)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
