using ChampionChallenges.Application.DTOs.Auth;
using ChampionChallenges.Application.Interfaces.Services;

namespace ChampionChallenges.Application.Services;

public class AuthService : IAuthService
{
    public Task<AuthResponseDto> Authenticate(LoginDto loginRequest)
    {
        throw new NotImplementedException();
    }
}