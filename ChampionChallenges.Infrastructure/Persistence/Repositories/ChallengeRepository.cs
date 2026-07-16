using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;
using ChampionChallenges.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChampionChallenges.Infrastructure.Persistence.Repositories;

public class ChallengeRepository(AppDbContext context) : BaseRepository<Challenge>(context), IChallengeRepository
{
    // Detalhe completo — desafiante + todos os convites com os desafiados
    public async Task<Challenge?> GetByIdWithDetailsAsync(Guid id)
    {
        return await context.Challenges
            .AsNoTracking()
            .Include(c => c.Challenger)
            .Include(c => c.Invites)
                .ThenInclude(i => i.Challenged)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // Lista — só o desafiante, sem carregar todos os convites
    public async Task<IEnumerable<Challenge>> GetAllWithChallengerAsync()
    {
        return await context.Challenges
            .AsNoTracking()
            .Include(c => c.Challenger)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    // Desafios criados por um usuário
    // Note: parameter name is 'challengerId' but maps to Challenge.UserId (the owner/creator)
    public async Task<IEnumerable<Challenge>> GetByChallengerIdAsync(Guid challengerId)
    {
        return await context.Challenges
            .AsNoTracking()
            .Include(c => c.Challenger)
            .Where(c => c.UserId == challengerId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    // Desafios em que o usuário foi convidado
    public async Task<IEnumerable<Challenge>> GetByChallengedIdAsync(Guid challengedId)
    {
        return await context.Challenges
            .AsNoTracking()
            .Include(c => c.Challenger)
            .Where(c => c.Invites.Any(i => i.ChallengedId == challengedId))
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }
}
