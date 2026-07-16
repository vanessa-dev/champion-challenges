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
        
        builder.Property(u => u.Id)
            .HasColumnType("binary(16)")
            .HasConversion(
                v => v.ToByteArray(),
                v => new Guid(v)
            );
        
        builder.Property(u => u.ChallengerId)
            .HasColumnName("id_sender")
            .HasColumnType("binary(16)")
            .HasConversion(
                v => v.ToByteArray(),
                v => new Guid(v)
            )
            .IsRequired();
        
        builder.Property(u => u.ChallengedId)
            .HasColumnName("id_recipient")
            .HasColumnType("binary(16)")
            .HasConversion(
                v => v.ToByteArray(),
                v => new Guid(v)
            )
            .IsRequired();
        
        builder.Property(u => u.ChallengeId)
            .HasColumnName("id_challenge")
            .HasColumnType("binary(16)")
            .HasConversion(
                v => v.ToByteArray(),
                v => new Guid(v)
            )
            .IsRequired();
        
        builder.Property(u => u.InvitedAt).HasColumnName("sent_at").IsRequired();
        builder.Property(u => u.RespondedAt).HasColumnName("responded_at");
        builder.Property(u => u.Status).HasColumnName("status").IsRequired();
        builder.Property(u => u.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
        
        // Navigation: Invite -> Challenged User
        builder.HasOne(i => i.Challenged)
            .WithMany()
            .HasForeignKey(i => i.ChallengedId)
            .HasConstraintName("fk_invite_recipient")
            .OnDelete(DeleteBehavior.Restrict);
        
        // Navigation: Invite -> Challenge (configured from Challenge side)
    }
}