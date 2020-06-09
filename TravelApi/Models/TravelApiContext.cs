using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
  public class TravelApiContext : DbContext
  {

    public TravelApiContext(DbContextOptions<TravelApiContext> options)
        : base(options)
    {
    }

    public DbSet<Place> Places { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Place>()
          .HasData(
            new Place { PlaceId = 1, City = "Tokyo", Country = "Japan", Rating = 2 },
            new Place { PlaceId = 2, City = "Seattle", Country = "US", Rating = 4 },
            new Place { PlaceId = 3, City = "London", Country = "England", Rating = 3 });
      builder.Entity<Review>()
          .HasData(
            new Review { ReviewId = 1, ReviewText = "Great!", PlaceId = 1, Rating = 2 },
            new Review { ReviewId = 2, ReviewText = "I hated this place!", PlaceId = 2, Rating = 1 },
            new Review { ReviewId = 3, ReviewText = "Highly recommend!!", PlaceId = 3, Rating = 4 }

          );
    }
  }
}