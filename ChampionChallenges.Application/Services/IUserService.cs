using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Services;

public interface IUserService : IBaseService<User>
{
   public Task<User?> GetByEmail(string email);
}