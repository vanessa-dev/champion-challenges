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

    public async Task<UserResponseDto> Update(UpdateUserDto requestDto)
    {
        var user = await userRepository.GetById(requestDto.Id);
        if (user == null)
            throw new Exception("Erro ao atualizar Usuario");
        
        var userEmailExists = await userRepository.GetByEmail(requestDto.Email);
        if (userEmailExists != null)
            throw new Exception("Erro ao atualizar Usuario");
        
        user.SetEmail(requestDto.Email);
        user.SetName(requestDto.Name);
        user.SetPassword(requestDto.Password, passwordHasher);
        
        await userRepository.Update(user);
        return user.ToResponse();
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

    public async Task<UserResponseDto?> GetByEmail(string email)
    {
        var user = await userRepository.GetByEmail(email);
        return user?.ToResponse();
    }
}