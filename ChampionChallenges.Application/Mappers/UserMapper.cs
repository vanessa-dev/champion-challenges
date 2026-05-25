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
        return new UserResponseDto(user.Id, user.Name, user.Email, user.RolePermission, user.UserStatus, user.CreatedAt, user.UpdatedAt);
    }

    public static UserShortResponseDto ToShortResponse(this User user)
    {
        return new UserShortResponseDto(user.Id, user.Name, user.Email, user.RolePermission, user.UserStatus);
    }
    
    public static IList<UserResponseDto> ToResponse(this IEnumerable<User> users)
    {
       return users.Select(user => user.ToResponse()).ToList();
    }

    public static IReadOnlyList<UserShortResponseDto> ToShortResponse(this IEnumerable<User> users)
    {
        return users.Select(user => user.ToShortResponse()).ToList();
    }

    public static CreateUserDto ToRequest(this User dto)
    {
        return new CreateUserDto(dto.Name, dto.Email, dto.Password, dto.RolePermission, dto.UserStatus);
    }
}
