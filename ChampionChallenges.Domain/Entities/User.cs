namespace ChampionChallenges.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Photo { get; private set; }
    public bool Status { get; private set; }
}