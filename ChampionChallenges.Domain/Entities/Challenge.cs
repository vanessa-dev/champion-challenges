namespace ChampionChallenges.Domain.Entities;

public class Challenge(string name, string details, bool status, string link, DateTime endDate, Guid userId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Details { get; private set; } = details;
    public DateTime StartDate { get; private set; } = DateTime.UtcNow;
    public DateTime EndDate { get; private set; } = endDate;
    public bool Status { get; private set; } = status;
    public string Link { get; private set; } = link;
    public Guid UserId { get; private set; } = userId;
}