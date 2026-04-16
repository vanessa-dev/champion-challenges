namespace ChampionChallenges.Application.DTOs.Invite;

public class SendInviteDto(Guid senderId, Guid recipientId, Guid challengeId) 
{
    public Guid SenderId { get; private set; } = senderId;
    public Guid RecipientId { get; private set; } = recipientId;
    public Guid ChallengeId { get; private set; } = challengeId;
}