using System;
using Microsoft.EntityFrameworkCore;

namespace cw12_ef.Models;

public class GamesContext : DbContext
{
    public GamesContext(DbContextOptions<GamesContext> options) : base (options)
    { }
    public DbSet<Game> Games { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Game>().HasData(
            new Game
            {
                Id = 1,
                Title = "The Legend of Zelda: Breath of the Wild",
                Publisher = "Nintendo",
                Price = 59.99
            },
            new Game
            {
                Id = 2,
                Title = "Cyberpunk 2077",
                Publisher = "CD Projekt Red",
                Price = 49.99
            },
            new Game
            {
                Id = 3,
                Title = "Elden Ring",
                Publisher = "Bandai Namco Entertainment",
                Price = 59.99
            },
            new Game
            {
                Id = 4,
                Title = "Among Us",
                Publisher = "Innersloth",
                Price = 4.99
            },
            new Game
            {
                Id = 5,
                Title = "Hollow Knight",
                Publisher = "Team Cherry",
                Price = 14.99
            }
        );
    }
}
