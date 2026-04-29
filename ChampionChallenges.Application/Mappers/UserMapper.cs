using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Mappers;


public static class UserMapper
{
    //Converter para entidade
    public static User ToEntity(this CreateUserDto dto)
    {
        return new User(dto.Name, dto.Email, dto.Password);
    }
    
    //Converter para DTO
    public static UserResponseDto ToResponse(this User user)
    {
        return new UserResponseDto(user.Id, user.Name, user.Email);
    }
    
    public static IList<UserResponseDto> ToResponse(this IList<User> users)
    {
       return users.Select(user => user.ToResponse()).ToList();
    }

    public static CreateUserDto ToRequest(this User dto)
    {
        return new CreateUserDto(dto.Name, dto.Email, dto.Password);
    }
}