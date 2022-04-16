using Microsoft.EntityFrameworkCore;

namespace RentAThing.Models
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options)
            : base(options)
        {
        }

        public DbSet<Thing> Things { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thing>().ToTable("Thing");
        }
    }
}