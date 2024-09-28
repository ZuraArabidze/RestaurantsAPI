using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
namespace Restaurants.Infrastructure.Persistence
{
    internal class RestaurantsDbContext: DbContext
    {
        internal DbSet<Restaurant>  Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RestaurantsDb;Trusted_Connection=True;",
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishies)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
              


        }

    }
}
