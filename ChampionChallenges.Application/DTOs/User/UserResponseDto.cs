namespace ChampionChallenges.Application.DTOs.User;

public class UserResponseDto(Guid id, string name, string email)
{
    public Guid Id { get; set; } = id;
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
}