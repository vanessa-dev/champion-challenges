using ChampionChallenges.Application.DTOs.User;
using FluentValidation;

namespace ChampionChallenges.Application.Validators.User;

public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordDto>
{
    public UpdatePasswordValidator()
    {
        RuleFor(dto => dto.CurrentPassword)
            .NotEmpty()
            .WithMessage("Current Password is required");
        
        RuleFor(dto => dto.NewPassword)
            .NotEmpty()
            .WithMessage("New password is required");
        
        RuleFor(dto => dto.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Password is required")
            .Equal(dto => dto.NewPassword)
            .WithMessage("New Password and confirm password do not match");
    }
}