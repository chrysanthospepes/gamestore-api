using Microsoft.EntityFrameworkCore;
using GameStore.Api.Models;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContect = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContect.Database.Migrate();
    }

    public static void AddGamesStoreDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("GameStore");
        builder.Services.AddSqlite<GameStoreContext>(
            connString,
            optionsAction: options => options.UseSeeding((context, _) =>
            {
                if (!context.Set<Genre>().Any())
                {
                    context.Set<Genre>().AddRange(
                        new Genre {Name = "Fighting"},
                        new Genre {Name = "RPG"},
                        new Genre {Name = "Platformer"},
                        new Genre {Name = "Racing"},
                        new Genre {Name = "Sports"}
                    );

                    context.SaveChanges();
                }
            })
    );
    }
}
