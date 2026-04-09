namespace ChampionChallenges.Domain.Entities;

public class ChallengeParticipant(Guid challengeId, Guid userId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ChallengeId { get; private set; } = challengeId;
    public Guid UserId { get; private set; } = userId;
}