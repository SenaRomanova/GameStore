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



}
