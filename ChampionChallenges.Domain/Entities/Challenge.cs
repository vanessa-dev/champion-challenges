using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Domain.Validators;
using FluentValidation;

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
    
    public User Challenger { get; private set; } = null!;
    public ICollection<Invite> Invites { get; private set; } = [];

    public Invite Invite(Guid challengedId) => new (UserId, challengedId, Id);

    public void UpdateData(string name, string details, string link, DateTime? endDate, ChallengeStatus status)
    {
        Name = name;
        Details = details;
        Link = link;
        EndDate = endDate;
        Status = status;
    }

    public override bool Validate()
    {
        var validator = new ChallengeValidator();
        var result = validator.Validate(this);
        
        if (!result.IsValid)
            throw new ValidationException(result.Errors);
        
        return true;
    }
}