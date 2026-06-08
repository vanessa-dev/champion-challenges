using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Domain.Exceptions;
using ChampionChallenges.Domain.Validators;

namespace ChampionChallenges.Domain.Entities;

public class User(
    string name,
    string email,
    string password,
    UserRolePermission rolePermission,
    UserStatus userStatus = UserStatus.Enabled,
    string? photo = null) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public string? Photo { get; private set; } = photo;
    public UserStatus UserStatus { get; private set; } = userStatus;
    public UserRolePermission RolePermission { get; private set; } = rolePermission;
    private readonly List<string> _errors = new List<string>();
    
    public void Disable()
    {
        if (UserStatus == UserStatus.Disabled)
            return;

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
        //Todo: Adicionar Validacao para checar se o usuario tem permissao
        // para mudar a senha.
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