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
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thing>().ToTable("Thing");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}