namespace ChampionChallenges.Application.DTOs.Challenge;

public class CreateChallengeDto(string name, string details, DateTime endDate, Guid userId)
{
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public DateTime StartDate { get; private set; } = DateTime.UtcNow;
    public DateTime EndDate { get; private set; } = endDate;
    public Guid UserId { get; private set; } = userId;
}