using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;
using ChampionChallenges.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChampionChallenges.Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}