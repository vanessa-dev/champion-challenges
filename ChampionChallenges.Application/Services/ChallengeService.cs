using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Mappers;
using ChampionChallenges.Domain.Repositories;

namespace ChampionChallenges.Application.Services;

public class ChallengeService(IChallengeRepository challengeRepository) : IChallengeService
{
    public  async Task<ChallengeResponseDto> Add(CreateChallengeDto entity)
    {
        var challenge = entity.ToEntity();
        await challengeRepository.Create(challenge);
        return challenge.ToResponse();
    }

    public Task<ChallengeResponseDto> Update(CreateChallengeDto entity)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<ChallengeResponseDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ChallengeResponseDto?> GetById(Guid id)
    {
        var challenge = await challengeRepository.GetById(id);
        return challenge?.ToResponse();
    }
}