using Microsoft.EntityFrameworkCore;
using WestwindSystem.Entities;

namespace WestwindSystem.DAL
{
    internal class WestwindContext : DbContext
    {
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)
        {

        }

        public DbSet<BuildVersion> BuildVersions => Set<BuildVersion>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Product> Products => Set<Product>();

        public virtual DbSet<Region> Regions { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Territory> Territories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Region>(entity =>
        //    {
        //        entity.HasKey(e => e.RegionId)
        //            .HasName("PK_Region")
        //            .IsClustered(false);

        //        entity.Property(e => e.RegionDescription).IsFixedLength();
        //    });

        //    modelBuilder.Entity<Territory>(entity =>
        //    {
        //        entity.HasKey(e => e.TerritoryId).IsClustered(false);

        //        entity.Property(e => e.TerritoryDescription).IsFixedLength();

        //        entity.HasOne(d => d.Region).WithMany(p => p.Territories)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Territories_Region");
        //    });

        //}

    }
}
