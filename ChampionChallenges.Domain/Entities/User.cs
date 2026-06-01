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
    public UserRolePermission RolePermission { get; set; } 
    private readonly List<string> _errors = new List<string>();
    
    public void ChangePassword(IPasswordHasher<User> passwordHasher)
    {
        Password = passwordHasher.HashPassword(this, Password);
        SetUpdatedAt();
    }
    
    public void SetPassword(string password) => Password = password;
    
    public void Disable()
    {
        if (UserStatus == UserStatus.Disabled)
            throw new DomainException("User is already disabled");

        UserStatus = UserStatus.Disabled;
        SetUpdatedAt();
    }
    
    public void Enable()
    {
        if (UserStatus == UserStatus.Enabled)
            return;

        UserStatus = UserStatus.Enabled;
        SetUpdatedAt();
    }

   
    public void ChangePassword(string newHash)
    {
        Password = newHash;
        SetUpdatedAt();
    }
    
    public void UpdateData(
        string name,
        string email,
        UserRolePermission rolePermission)
    {
        Name = name;
        Email = email;
        RolePermission = rolePermission;

        SetUpdatedAt();
    }
    
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