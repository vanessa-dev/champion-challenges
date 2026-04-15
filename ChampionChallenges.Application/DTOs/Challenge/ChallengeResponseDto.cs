using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.Challenge;

public class ChallengeResponseDto(Guid id, string name, string details, string link, Guid userId)
{
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public string Link { get; private set; } = link;
    public Guid UserId { get; private set; } = userId;
}