using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Mappers;
using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;

namespace ChampionChallenges.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    
    public async Task<UserResponseDto> Add(CreateUserDto requestDto)
    {
       //O email precisa ser valido
       //O email precisa ser unico
       //A senha precisa ser criptografada(nao usar bycrypt, identity)
       
       var entity = requestDto.ToEntity();
       await userRepository.Add(entity);
       return entity.ToResponse();
    }

    public Task<UserResponseDto> Update(CreateUserDto requestDto)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserResponseDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDto?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }
}