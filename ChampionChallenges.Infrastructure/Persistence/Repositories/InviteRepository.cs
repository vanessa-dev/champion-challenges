using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;
using ChampionChallenges.Infrastructure.Repositories;

namespace ChampionChallenges.Infrastructure.Persistence.Repositories;

public class InviteRepository(AppDbContext context) : BaseRepository<Invite>(context), IInviteRepository
{
    
}