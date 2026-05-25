using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.User;

public class UserFilterRequestDto
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public UserRolePermission? RolePermission { get; init; }
    public UserStatus? Status { get; init; }
    public int PageSize { get; init; } = 20;
    public int Page { get; init; } = 1;
}
