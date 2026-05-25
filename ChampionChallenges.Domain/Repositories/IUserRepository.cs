using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<User?> GetByEmail(string email);
    public Task<(IReadOnlyList<User> Items, int TotalItems)> GetPaged(int pageSize, int page,
        string? name, string? email, UserRolePermission? rolePermission, UserStatus? status
    );
}
