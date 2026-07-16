using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Interfaces.Services;

public interface IChallengeService 
{
    public Task<ChallengeResponseDto> Add(CreateChallengeDto entity);
    public Task<ChallengeResponseDto> Update(UpdateChallengeDto entity);
    public Task Remove(Guid id);
    
    public Task<IList<ChallengeResponseDto>> GetAll(Guid? ownerId = null, Guid? invitedUserId = null);
    public Task<ChallengeResponseDto?> GetById(Guid id);
}