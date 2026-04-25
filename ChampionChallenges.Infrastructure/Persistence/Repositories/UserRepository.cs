using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;

namespace ChampionChallenges.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public Task<User?> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }
}