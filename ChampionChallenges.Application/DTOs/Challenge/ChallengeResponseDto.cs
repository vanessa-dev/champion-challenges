using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.Challenge;

public class ChallengeResponseDto(
    Guid id, 
    string name, 
    string details, 
    string link, 
    Guid userId,
    DateTime startDate,
    DateTime? endDate,
    ChallengeStatus status,
    string? ownerName = null,
    IList<InviteSummaryDto>? invites = null)
{
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public string Link { get; private set; } = link;
    public Guid UserId { get; private set; } = userId;
    public DateTime StartDate { get; private set; } = startDate;
    public DateTime? EndDate { get; private set; } = endDate;
    public ChallengeStatus Status { get; private set; } = status;
    public string? OwnerName { get; private set; } = ownerName;
    public IList<InviteSummaryDto>? Invites { get; private set; } = invites;
}