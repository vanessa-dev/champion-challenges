using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Domain.Entities;

public class Challenge(string name, string details, string link, DateTime endDate, Guid userId) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public DateTime StartDate { get; private set; } = DateTime.UtcNow;
    public DateTime EndDate { get; private set; } = endDate;
    public ChallengeStatus Status { get; private set; } = ChallengeStatus.Pending;
    public string Link { get; private set; } = link;
    public Guid UserId { get; private set; } = userId;
}