namespace ChampionChallenges.Application.DTOs.Auth;

public class LoginDto(string email, string password)
{
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
}