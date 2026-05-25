using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Enums;
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

    public async Task<(IReadOnlyList<User> Items, int TotalItems)> GetPaged(int pageSize, int page, string? name, string? email, UserRolePermission? rolePermission,
        UserStatus? status)
    {
        IQueryable<User> query = context.Users.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            query = query.Where(x => x.Email.Contains(email));
        }

        if (rolePermission.HasValue)
        {
            query = query.Where(x => x.RolePermission == rolePermission.Value);
        }
        
        if (status.HasValue)
        {
            query = query.Where(x => x.UserStatus == status.Value);
        }

        var totalItems = await query.CountAsync();
        
        var items = await query
            .OrderBy(x => x.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalItems);
    }
}
