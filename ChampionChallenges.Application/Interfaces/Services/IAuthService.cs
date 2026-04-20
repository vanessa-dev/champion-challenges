using ChampionChallenges.Application.DTOs.Auth;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Interfaces.Services;

public interface IAuthService
{
    public Task<AuthResponseDto> Authenticate(LoginDto loginRequest);
}