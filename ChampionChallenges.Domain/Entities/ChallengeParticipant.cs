namespace ChampionChallenges.Domain.Entities;

public class ChallengeParticipant
{
    public Guid Id { get; private set; }
    public Guid ChallengeId { get; private set; }
    public Guid UserId { get; private set; }
}