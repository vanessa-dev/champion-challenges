using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;

namespace ChampionChallenges.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public Task Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}