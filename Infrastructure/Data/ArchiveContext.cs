using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ArchiveContext : DbContext
    {
        public ArchiveContext(DbContextOptions<ArchiveContext> options) : base(options)
        {
        }

        public DbSet<Box> Boxes { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Policy>()
            .HasOne<Box>(b => b.Box)
            .WithMany(p => p.Policies)
            .HasForeignKey(s => s.BoxId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Policy>()
            .Property(p => p.Code)
            .IsRequired();
            modelBuilder.Entity<Policy>()
            .Property(p => p.Name)
            .IsRequired();
            modelBuilder.Entity<Policy>()
            .Property(p => p.PolicyType)
            .IsRequired();
            modelBuilder.Entity<Policy>()
            .Property(p => p.PolicyNumber)
            .IsRequired();

            modelBuilder.Entity<Box>()
            .Property(p => p.Code)
            .IsRequired();
            modelBuilder.Entity<Box>()
            .Property(p => p.DestructionFlag)
            .IsRequired();
    }
    }
}