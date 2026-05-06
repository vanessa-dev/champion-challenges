namespace ChampionChallenges.Application.DTOs.User;

public class UpdateUserDto(Guid id, string name, string email, string password)
{
    // TODO: Adicionar para poder atualizar mais campos como por exemplo a foto, porenquanto e suficiente.
    public Guid Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
}