using ChampionChallenges.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChampionChallenges.Infrastructure.Persistence.Configuration;

public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.ToTable("challenge");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
        .HasColumnType("binary(16)")
        .HasConversion(
            v => v.ToByteArray(),
            v => new Guid(v)
        );
        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Link).IsRequired();
        builder.Property(u => u.StartDate).HasColumnName("start_date").IsRequired();
        builder.Property(u => u.EndDate).HasColumnName("end_date");
        builder.Property(u => u.UserId).IsRequired().HasColumnName("id_owner")
        .HasColumnType("binary(16)")
        .HasConversion(
            v => v.ToByteArray(),
            v => new Guid(v)
        );
        builder.Property(u => u.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
    }
}