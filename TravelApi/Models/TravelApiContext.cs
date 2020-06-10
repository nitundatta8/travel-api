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
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Place>()
          .HasData(
            new Place { PlaceId = 1, City = "Tokyo", Country = "Japan", Rating = 2 },
            new Place { PlaceId = 2, City = "Seattle", Country = "US", Rating = 4 },
            new Place { PlaceId = 3, City = "London", Country = "England", Rating = 3 });
      builder.Entity<Review>()
          .HasData(
            new Review { ReviewId = 1, ReviewText = "Great!", Rating = 2 },
            new Review { ReviewId = 2, ReviewText = "I hated this place!", Rating = 1 },
            new Review { ReviewId = 3, ReviewText = "Highly recommend!!", Rating = 4 }
          );
      builder.Entity<User>()
      .HasData(
        new User { Id = 1, FirstName = "Nitun", LastName = "Datta", Username = "test", Password = "test" },
        new User { Id = 2, FirstName = "Purba", LastName = "Devi", Username = "test1", Password = "test1" }


      );
    }
  }
}