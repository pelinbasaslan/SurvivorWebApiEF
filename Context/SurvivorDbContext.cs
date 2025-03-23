using Microsoft.EntityFrameworkCore;
using SurvivorWebApiEF.Entities;

namespace SurvivorWebApiEF.Context
{
    public class SurvivorDbContext : DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CompetitorEntity> Competitors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure DateTime properties to use timestamptz (timestamp with time zone)
            modelBuilder.Entity<CategoryEntity>()
                .Property(c => c.CreatedDate)
                .HasColumnType("timestamptz"); // Use timestamp with time zone
            modelBuilder.Entity<CategoryEntity>()
                .Property(c => c.ModifiedDate)
                .HasColumnType("timestamptz");

            modelBuilder.Entity<CompetitorEntity>()
                .Property(c => c.CreatedDate) // Assuming `CreatedAt` is a DateTime property
                .HasColumnType("timestamptz"); // Use timestamp with time zone
            modelBuilder.Entity<CompetitorEntity>()
                .Property(c => c.ModifiedDate) // Assuming `CreatedAt` is a DateTime property
                .HasColumnType("timestamptz");
        }
    }
}