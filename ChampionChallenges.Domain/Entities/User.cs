namespace ChampionChallenges.Domain.Entities;

public class User(string name, string email, string password, string photo, bool status)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public string Photo { get; private set; } = photo;
    public bool Status { get; private set; } = status;
}