using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Domain.Entities;

public class Invite(Guid senderId, Guid recipientId, Guid challengeId, DateTime respondedAt) : BaseEntity
{
    public Guid SenderId { get; private set; } = senderId;
    public Guid RecipientId { get; private set; } = recipientId;
    public Guid ChallengeId { get; private set; } = challengeId;
    public DateTime SentAt { get; private set; } = DateTime.UtcNow;
    public DateTime RespondedAt { get; private set; } = respondedAt;
    public InviteStatus Status { get; private set; } = InviteStatus.Pending;
}