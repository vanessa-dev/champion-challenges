using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.User;

public class UpdateUserDto(Guid id, string name, string email, UserRolePermission permission)
{
    
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public UserRolePermission Permission { get; private set; } = permission;
}