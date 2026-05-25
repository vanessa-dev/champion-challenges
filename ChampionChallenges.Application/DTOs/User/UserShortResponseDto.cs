using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.User;

public class UserShortResponseDto(
    Guid id,
    string name,
    string email,
    UserRolePermission rolePermission,
    UserStatus status)
{
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public UserRolePermission RolePermission { get; private set; } = rolePermission;
    public UserStatus Status { get; private set; } = status;
}
