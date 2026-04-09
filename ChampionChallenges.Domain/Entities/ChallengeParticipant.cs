namespace ChampionChallenges.Domain.Entities;

public class ChallengeParticipant(Guid challengeId, Guid userId) : BaseEntity
{
    public Guid ChallengeId { get; private set; } = challengeId;
    public Guid UserId { get; private set; } = userId;
}