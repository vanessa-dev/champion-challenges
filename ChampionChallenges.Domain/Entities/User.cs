using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Domain.Entities;

public class User(string name, string email, string password, string? photo = null) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public string? Photo { get; private set; } = photo;
    public UserStatus UserStatus { get; private set; } = UserStatus.Enabled;
}