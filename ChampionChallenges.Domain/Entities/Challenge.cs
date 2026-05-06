using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Domain.Entities;

public class Challenge(string name, string details, string link, Guid userId, DateTime? endDate = null) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public DateTime StartDate { get; private set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; private set; } = endDate;
    public ChallengeStatus Status { get; private set; } = ChallengeStatus.Pending;
    public string Link { get; private set; } = link;
    public Guid UserId { get; private set; } = userId;
    
    public  User Challenger { get; private set; }
    public ICollection<Invite> Invites { get; private set; } = [];

    public Invite Invite(Guid challengedId) => new (Id, challengedId);
    
    
}