using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Domain.Entities;

public class Invite
{
    public Guid Id { get; private set; }
    public Guid SenderId { get; private set; }
    public Guid RecipientId { get; private set; }
    public Guid ChallengeId { get; private set; }
    public DateTime SentAt { get; private set; }
    public DateTime RespondedAt { get; private set; }
    public InviteStatus Status { get; private set; }
}