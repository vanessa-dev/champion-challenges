using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.Challenge;

public class ChallengeResponseDto(Guid id, string name, string details, string link, DateTime endDate, DateTime startDate, Guid userId, ChallengeStatus status)
{
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public DateTime StartDate { get; private set; } = startDate;
    public DateTime EndDate { get; private set; } = endDate;
    public ChallengeStatus Status { get; private set; } = status;
    public string Link { get; private set; } = link;
    public Guid UserId { get; private set; } = userId;
}