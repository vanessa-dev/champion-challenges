namespace ChampionChallenges.Application.DTOs.Invite;

public class InviteResponseDto(Guid id, Guid senderId, Guid recipientId, Guid challengeId, DateTime sentAt)
{
    public Guid Id { get; private set; } = id;
    public Guid SenderId { get; private set; } = senderId;
    public Guid RecipientId { get; private set; } = recipientId;
    public Guid ChallengeId { get; private set; } = challengeId;
    public DateTime SentAt { get; private set; } = sentAt;
    
}