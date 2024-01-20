using DataBaseMinimalApi.Context;
using Microsoft.EntityFrameworkCore;
using Models.DBO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option=> option.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.MapGet("/players", async (AppDbContext context) => {
    var players = await context.Set<Player>().ToListAsync();
    return players.Count == 0 ? Results.NotFound("No players already created") : Results.Ok(players);
});

app.MapGet("/player/{id:int}", async (int id, AppDbContext context) => {
    var player = await context.Set<Player>().FindAsync(id);
    return player is null ? Results.NotFound("Wrong id?") : Results.Ok(player);
});

app.MapPut("/player", async (string test, AppDbContext context) => {
    var player = new Player { Name = test };
    context.Set<Player>().Add(player);
    await context.SaveChangesAsync();
    return Results.Ok(player);
});

app.MapPatch("/player", async (Player player, AppDbContext context) => {
    if (await context.Set<Player>().FindAsync(player.Id) is null)
        return Results.NotFound("Wrong id?");
    context.Update(player);
    await context.SaveChangesAsync();
    return Results.Ok(player);
});

app.MapDelete("/player/{id:int}", async (int id, AppDbContext context) => {
    if (await context.Set<Player>().FindAsync(id) is not {} player)
        return Results.NotFound("Wrong id?");
    context.Set<Player>().Remove(player);
    await context.SaveChangesAsync();
    return Results.Ok();
});


app.Run();