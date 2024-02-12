using Domain.Entities.Event;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Setup
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<EventEntity> Events { get; set; }
        public virtual DbSet<EventAttendantEntity> EventAttendants { get; set; }

        public DatabaseContext(
            DbContextOptions<DatabaseContext> options
        ) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventEntity>()
                .HasMany(e => e.EventAttendants)
                .WithOne()
                .HasForeignKey(e => e.EventId)
                .IsRequired();
        }
    }
}
