using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Mappers;
using ChampionChallenges.Domain.Exceptions;
using ChampionChallenges.Domain.Repositories;

namespace ChampionChallenges.Application.Services;

public class ChallengeService(IChallengeRepository challengeRepository) : IChallengeService
{
    public async Task<ChallengeResponseDto> Add(CreateChallengeDto entity)
    {
        var challenge = entity.ToEntity();
        challenge.Validate();
        await challengeRepository.Create(challenge);
        return challenge.ToResponse();
    }

    public async Task<ChallengeResponseDto> Update(UpdateChallengeDto entity)
    {
        var challenge = await challengeRepository.GetById(entity.Id);
        
        if (challenge == null)
            throw new DomainException("Challenge not found");
        
        challenge.ApplyUpdate(entity);
        challenge.Validate();
        await challengeRepository.Update(challenge);
        
        return challenge.ToResponse();
    }

    public async Task Remove(Guid id)
    {
        var challenge = await challengeRepository.GetById(id);
        
        if (challenge == null)
            throw new DomainException("Challenge not found");
        
        await challengeRepository.Remove(id);
    }

    public async Task<IList<ChallengeResponseDto>> GetAll(Guid? ownerId = null, Guid? invitedUserId = null)
    {
        // Validate mutually exclusive filters
        if (ownerId.HasValue && invitedUserId.HasValue)
            throw new DomainException("Cannot filter by both ownerId and invitedUserId simultaneously");

        IEnumerable<Domain.Entities.Challenge> challenges;

        if (ownerId.HasValue)
        {
            // Get challenges created by specific user
            challenges = await challengeRepository.GetByChallengerIdAsync(ownerId.Value);
        }
        else if (invitedUserId.HasValue)
        {
            // Get challenges where user was invited
            challenges = await challengeRepository.GetByChallengedIdAsync(invitedUserId.Value);
        }
        else
        {
            // Get all challenges with owner info
            challenges = await challengeRepository.GetAllWithChallengerAsync();
        }

        return challenges.Select(c => c.ToResponseWithOwner()).ToList();
    }

    public async Task<ChallengeResponseDto?> GetById(Guid id)
    {
        var challenge = await challengeRepository.GetByIdWithDetailsAsync(id);
        return challenge?.ToResponseWithDetails();
    }
}
