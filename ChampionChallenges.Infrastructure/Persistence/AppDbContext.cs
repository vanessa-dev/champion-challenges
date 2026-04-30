using ChampionChallenges.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampionChallenges.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Challenge> Challenges { get; private set; }
    public DbSet<User> Users { get; private set; }
    public DbSet<Invite> Invites { get; private set; }
    public DbSet<ChallengeParticipant> ChallengeParticipants { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}