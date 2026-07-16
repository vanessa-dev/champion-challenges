using ChampionChallenges.Domain.Entities;
using FluentValidation;

namespace ChampionChallenges.Domain.Validators;

public class ChallengeValidator : AbstractValidator<Challenge>
{
    public ChallengeValidator()
    {
        RuleFor(entity => entity)
            .NotEmpty()
            .WithMessage("entity invalid")
            .NotNull()
            .WithMessage("entity invalid");

        RuleFor(entity => entity.Name)
            .NotEmpty()
            .WithMessage("name is required")
            .NotNull()
            .WithMessage("name is required")
            .MaximumLength(100)
            .WithMessage("name must not exceed 100 characters");

        RuleFor(entity => entity.Details)
            .NotEmpty()
            .WithMessage("details is required")
            .NotNull()
            .WithMessage("details is required");

        RuleFor(entity => entity.Link)
            .NotEmpty()
            .WithMessage("link is required")
            .NotNull()
            .WithMessage("link is required");

        RuleFor(entity => entity.UserId)
            .NotEmpty()
            .WithMessage("userId is required");

        RuleFor(entity => entity.Status)
            .IsInEnum()
            .WithMessage("status is invalid");

        RuleFor(entity => entity)
            .Must(entity => !entity.EndDate.HasValue || entity.EndDate.Value >= entity.StartDate)
            .WithMessage("end date must be greater than or equal to start date");
    }
}
