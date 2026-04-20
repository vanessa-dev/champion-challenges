using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Interfaces.Services;

public interface IChallengeService : IBaseService<Challenge, CreateChallengeDto,ChallengeResponseDto >
{
    
}