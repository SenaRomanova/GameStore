using GameStore.api.Data;
using GameStore.api.DTOs;
using GameStore.api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameStore");//specifies the database file through a connection string
builder.Services.AddSqlite<GameStoreDbContext>(connectionString);
//entity framework will read the conn string, create instance of db context with that conn string


var app = builder.Build();

app.MapGamesEndpoints();
app.MigrateDb(); //applies any pending migrations for the context to the database

app.Run();
