using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.User;

public class CreateUserDto(string name, string email, string password, UserRolePermission rolePermission, UserStatus status)
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    
    public UserRolePermission RolePermission { get; private set; } = rolePermission;
    
    public UserStatus Status { get; private set; } = status;
}