namespace ChampionChallenges.Application.DTOs.Invite;

public class SendInviteDto(Guid recipientId, Guid challengeId) 
{
    public Guid RecipientId { get; private set; } = recipientId;
    public Guid ChallengeId { get; private set; } = challengeId;
    public DateTime SentAt { get; private set; } = DateTime.UtcNow;
}