using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        //we cannot access dbcontest directly, we need to create a scope
        //get an instance of scope:

        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();

        dbContext.Database.Migrate(); //applies any pending migrations for the context to the database
    }
}
