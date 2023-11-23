using AngularProject.Model;
using Microsoft.EntityFrameworkCore;

namespace AngularProject.Models.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<Favorite> Favorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Event>().HasData(
    new Event { eventId = 1, name = "Concert in the Park", description = "Enjoy live music in the open air.", location = "City Park", time = DateTime.Parse("2023-12-01 18:00:00") },
    new Event { eventId = 2, name = "Tech Conference", description = "Explore the latest trends in technology.", location = "Conference Center", time = DateTime.Parse("2023-12-05 09:00:00") },
    new Event { eventId = 3, name = "Food Festival", description = "A celebration of diverse cuisines.", location = "Downtown Square", time = DateTime.Parse("2023-12-10 12:00:00") },
    new Event { eventId = 4, name = "Sports Tournament", description = "Cheer for your favorite teams.", location = "Sports Complex", time = DateTime.Parse("2023-12-15 14:30:00") },
    new Event { eventId = 5, name = "Art Exhibition", description = "Explore the world of contemporary art.", location = "Art Gallery", time = DateTime.Parse("2023-12-20 10:00:00") },
    new Event { eventId = 6, name = "Movie Night", description = "Watch a blockbuster under the stars.", location = "Community Park", time = DateTime.Parse("2023-12-25 20:00:00") },
    new Event { eventId = 7, name = "Science Fair", description = "Hands-on experiments and demonstrations.", location = "Science Museum", time = DateTime.Parse("2023-12-30 13:00:00") },
    new Event { eventId = 8, name = "Book Club Meeting", description = "Discuss the latest literary masterpiece.", location = "Local Library", time = DateTime.Parse("2024-01-05 19:00:00") },
    new Event { eventId = 9, name = "Fitness Bootcamp", description = "Get fit with intense workouts.", location = "Fitness Studio", time = DateTime.Parse("2024-01-10 06:30:00") },
    new Event { eventId = 10, name = "Community Cleanup", description = "Join hands for a cleaner neighborhood.", location = "Various Locations", time = DateTime.Parse("2024-01-15 09:00:00") }
);
    }
}
