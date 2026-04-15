namespace ChampionChallenges.Application.DTOs.Challenge;

public class CreateChallengeDto(string name, string details, string link, Guid userId)
{
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public string Link { get; private set; } = link;
    public Guid UserId { get; private set; } = userId;
}