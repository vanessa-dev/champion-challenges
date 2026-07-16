using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.Challenge;

public class UpdateChallengeDto(Guid id, string name, string details, string link, DateTime? endDate, ChallengeStatus status)
{
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public string Link { get; private set; } = link;
    public DateTime? EndDate { get; private set; } = endDate;
    public ChallengeStatus Status { get; private set; } = status;
}
