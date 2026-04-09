using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<User?> GetByEmail(string email);
}