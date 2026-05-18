using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Domain.Exceptions;
using ChampionChallenges.Domain.Validators;
using Microsoft.AspNetCore.Identity;

namespace ChampionChallenges.Domain.Entities;

public class User(string name, string email, string password, string? photo = null) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public string? Photo { get; private set; } = photo;
    public UserStatus UserStatus { get; private set; } = UserStatus.Enabled;
    private readonly List<string> _errors = new List<string>();
    
    public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
    {
        Password = passwordHasher.HashPassword(this, password);
    }
    
    public void SetName(string name) => Name = name;
    public void SetEmail(string email) => Email = email;
    
    public override bool Validate()
    {
        var validator = new UserValidator();
        var validation = validator.Validate(this);
        if(!validation.IsValid){
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);

            throw new DomainException("Invalid Fields", _errors);
        }

        return true;
    }
}