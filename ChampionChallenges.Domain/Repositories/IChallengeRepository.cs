using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Domain.Repositories;

public interface IChallengeRepository : IBaseRepository<Challenge>
{
    Task<Challenge?> GetByIdWithDetailsAsync(Guid id);
    Task<IEnumerable<Challenge>> GetAllWithChallengerAsync();
    Task<IEnumerable<Challenge>> GetByChallengerIdAsync(Guid challengerId);
    Task<IEnumerable<Challenge>> GetByChallengedIdAsync(Guid challengedId);
}