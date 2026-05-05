using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Mappers;
using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ChampionChallenges.Application.Services;

public class UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher) : IUserService
{
    
    public async Task<UserResponseDto> Add(CreateUserDto requestDto)
    {
       //O email precisa ser valido
       var userExists = await userRepository.GetByEmail(requestDto.Email);
       if (userExists != null)
           throw new Exception("Erro ao criar Usuario");
       
       var entity = requestDto.ToEntity();
       entity.SetPassword(requestDto.Password, passwordHasher);
       await userRepository.Create(entity);
       return entity.ToResponse();
    }

    public async Task<UserResponseDto> Update(CreateUserDto requestDto)
    {
        var entity = requestDto.ToEntity();
        var userExists = await userRepository.GetById(entity.Id);
        if (userExists == null)
            throw new Exception("Erro ao atualizar Usuario");
        
        var userEmailExists = await userRepository.GetByEmail(requestDto.Email);
        if (userEmailExists != null)
            throw new Exception("Erro ao atualizar Usuario");
        
        entity.SetPassword(requestDto.Password, passwordHasher);
        
        await userRepository.Update(entity);
        return entity.ToResponse();
    }

    public async  Task Remove(Guid id)
    {
       await userRepository.Remove(id);
    }

    public async Task<IList<UserResponseDto>> GetAll()
    {
       var users = await userRepository.GetAll();
       return users.ToResponse();
    }

    public async Task<UserResponseDto?> GetById(Guid id)
    {
        var user = await userRepository.GetById(id);
        return user?.ToResponse();
    }

    public Task<UserResponseDto?> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }
}