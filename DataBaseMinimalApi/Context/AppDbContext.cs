namespace DataBaseMinimalApi.Context;

using Microsoft.EntityFrameworkCore;
using Models.DBO;
using System.Reflection;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardDeck> CardDecks { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<PlayerMove> PlayerMoves { get; set; }
    public DbSet<Session> Sessions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardDeck>()
            .HasOne(cd => cd.Session)
            .WithOne(s => s.CardDeck)
            .HasForeignKey<CardDeck>(cd => cd.SessionId);
    }
}