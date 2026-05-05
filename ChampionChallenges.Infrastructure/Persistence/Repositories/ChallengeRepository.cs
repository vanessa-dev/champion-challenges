using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;
using ChampionChallenges.Infrastructure.Repositories;

namespace ChampionChallenges.Infrastructure.Persistence.Repositories;

public class ChallengeRepository(AppDbContext context) : BaseRepository<Challenge>(context), IChallengeRepository
{

    // Detalhe completo — desafiante + todos os convites com os desafiados - busca
    public Task<Challenge?> GetByIdWithDetailsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    // Lista — só o desafiante, sem carregar todos os convites
    public Task<IEnumerable<Challenge>> GetAllWithChallengerAsync()
    {
        throw new NotImplementedException();
    }

    // Desafios criados por um usuário 
    public Task<IEnumerable<Challenge>> GetByChallengerIdAsync(Guid challengerId)
    {
        throw new NotImplementedException();
    }

    // Desafios em que o usuário foi convidado
    public Task<IEnumerable<Challenge>> GetByChallengedIdAsync(Guid challengedId)
    {
        throw new NotImplementedException();
    }
}