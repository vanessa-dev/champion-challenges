using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;
using ChampionChallenges.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChampionChallenges.Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext dbContext) : BaseRepository<User>, IUserRepository
{
    public async Task<User?> GetByEmail(string email)
    {
        return await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
    
    public  async Task Add(User entity)
    {
       await dbContext.Users.AddAsync(entity);
       await dbContext.SaveChangesAsync();
    }

    public async Task Remove(Guid id)
    {
        var users = await dbContext.Users.FindAsync(id);
        if (users != null)
        {
            dbContext.Users.Remove(users);
            await dbContext.SaveChangesAsync();
        }
     
    }

    public async Task Update(User entity)
    {
        dbContext.Users.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public Task<List<User>> GetAll()
    {
        var users = dbContext.Users.ToListAsync();
        return users;
    }

    public async  Task<User?> GetById(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        return user;
    }
}