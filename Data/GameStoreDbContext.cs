using System;
using System.Runtime.ConstrainedExecution;
using GameStore.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Data;

public class GameStoreDbContext(DbContextOptions<GameStoreDbContext> options)
    : DbContext(options) //provides info on connecting to the actual database
{
    public DbSet<Game> Games => Set<Game>(); //represents the Games enitiy table in the database; sets of type Game to create instance
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)//executed as soon as the migration is executed. This is where we can configure the model and seed initial data
    {
        modelBuilder.Entity<Genre>().HasData( //seeding initial data for Genres table taht will exist once migration completes.
            new Genre { Id = 1, Name = "Action-adventure" },
            new Genre { Id = 2, Name = "Platform" },
            new Genre { Id = 3, Name = "Action RPG" },
            new Genre { Id = 4, Name = "Shooter" },
            new Genre { Id = 5, Name = "Strategy" },
            new Genre { Id = 6, Name = "Puzzle" }
        );

    }

}

