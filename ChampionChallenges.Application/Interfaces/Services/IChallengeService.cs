using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Interfaces.Services;

public interface IChallengeService 
{
    public Task<ChallengeResponseDto> Add(CreateChallengeDto entity);
    public Task<ChallengeResponseDto> Update(CreateChallengeDto entity);
    public Task Remove(Guid id);
    
    public Task<IList<ChallengeResponseDto>> GetAll();
    public Task<ChallengeResponseDto?> GetById(Guid id);
}