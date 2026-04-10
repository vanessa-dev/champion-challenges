using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Interfaces.Services;

public interface IUserService : IBaseService<User, CreateUserDto, UserResponseDto>
{
   public Task<User?> GetByEmail(string email);
}