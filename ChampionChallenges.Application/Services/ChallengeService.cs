using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Application.Interfaces.Services;

namespace ChampionChallenges.Application.Services;

public class ChallengeService : IChallengeService
{
    public Task<ChallengeResponseDto> Add(CreateChallengeDto entity)
    {
        throw new NotImplementedException();
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

    public Task<ChallengeResponseDto?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}