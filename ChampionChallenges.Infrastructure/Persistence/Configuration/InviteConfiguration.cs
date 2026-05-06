using ChampionChallenges.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChampionChallenges.Infrastructure.Persistence.Configuration;

public class InviteConfiguration : IEntityTypeConfiguration<Invite>
{
    public void Configure(EntityTypeBuilder<Invite> builder)
    {
        builder.ToTable("invite");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.ChallengedId).IsRequired();
        builder.Property(u => u.ChallengerId).IsRequired();
        builder.Property(u => u.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
       
    }
}