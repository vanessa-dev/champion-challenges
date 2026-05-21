using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.User;

public class UpdatePasswordDto(string currentPassword, string newPassword, string confirmPassword)
{
    public string CurrentPassword { get; private set; } = currentPassword;
    public string NewPassword {get; private set; } = newPassword;
    public string ConfirmPassword { get; private set; } = confirmPassword;
}