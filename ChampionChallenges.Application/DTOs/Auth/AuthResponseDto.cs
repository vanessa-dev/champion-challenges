namespace ChampionChallenges.Application.DTOs.Auth;

public class AuthResponseDto(string email)
{
    public string Email { get; private set; } = email;
}