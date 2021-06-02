using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
  public class TravelContext : DbContext
  {
    public TravelContext(DbContextOptions<TravelContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Place>()
      .HasData(
        new Place { PlaceId = 1, Name = "Phi Phi Islands", Reviews = "Woolly Mammoth", Country = "Thailand" },
        new Place { PlaceId = 2, Name = "Yellow Stones", Reviews = "Dinosaur", Country = "United States" },
        new Place { PlaceId = 3, Name = "Rio de Janeiro", Reviews = "Dinosaur", Country = "Brazil"},
        new Place { PlaceId = 4, Name = "London", Reviews = "Shark", Country = "England" },
        new Place { PlaceId = 5, Name = "Paris", Reviews = "Dinosaur", Country = "France" }
      );
    }

    public DbSet<Place> Places { get; set; }
  }
}
