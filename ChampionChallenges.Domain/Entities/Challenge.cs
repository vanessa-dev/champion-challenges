namespace ChampionChallenges.Domain.Entities;

public class Challenge
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Details { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool Status { get; private set; }
    public string Link { get; private set; }
    public Guid UserId { get; private set; }
}