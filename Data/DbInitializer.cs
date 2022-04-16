using Microsoft.EntityFrameworkCore;

namespace RentAThing.Models
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RentalContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (context.Things.Any())
                {
                    return;   
                }

                context.Things.Add(new Thing { ID = 1 });
                context.SaveChanges();
            }
        }
    }
}