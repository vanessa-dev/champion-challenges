using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Domain.Entities;

public class Invite(Guid challengerId, Guid challengedId) : BaseEntity
{
    public Guid ChallengerId { get; private set; } = challengerId;
    public Guid ChallengedId { get; private set; } = challengedId;
   
    public DateTime InvitedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? RespondedAt { get; private set; }
    public InviteStatus Status { get; private set; } = InviteStatus.Pending;
    public Challenge Challenge { get; private set; }
    public User Challenged { get; private set; }

    public void Accept() =>
        (Status, RespondedAt) = (InviteStatus.Accepted, DateTime.UtcNow);

    public void Decline() =>
        (Status, RespondedAt) = (InviteStatus.Rejected, DateTime.UtcNow);
    
}