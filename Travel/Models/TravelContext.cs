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
        new Place { PlaceId = 1, Name = "Phi Phi Islands", Reviews = "An overdeveloped island that is good for partying but little else.", Country = "Thailand" },
        new Place { PlaceId = 2, Name = "Yellowstones", Reviews = "The park is truely a place that must be seen completely to appreciate.", Country = "United States" },
        new Place { PlaceId = 3, Name = "Rio de Janeiro", Reviews = "The city is known for its sprawling favelas (shanty towns).", Country = "Brazil"},
        new Place { PlaceId = 4, Name = "London", Reviews = "The city stands on the River Thames in the south-east of England.", Country = "England" },
        new Place { PlaceId = 5, Name = "Paris", Reviews = "the city is known for its cafe culture and designer boutiques along the Rue du Faubourg Saint-Honoré.", Country = "France" }
      );
    }

    public DbSet<Place> Places { get; set; }
  }
}
