using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Interfaces.Services;

public interface IUserService 
{
   public Task<UserResponseDto?> GetByEmail(string email);
   public Task<UserResponseDto> Add(CreateUserDto entity);
   public Task<UserResponseDto> Update(UpdateUserDto entity);
   public Task Remove(Guid id);
    
   public Task<IList<UserResponseDto>> GetAll();
   public Task<UserResponseDto?> GetById(Guid id);
}