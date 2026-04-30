using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Domain.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    public Task Add(T entity);
    public Task Remove(Guid id);
    public Task Update(T entity);
    public Task<List<T>> GetAll();
    public Task<T?> GetById(Guid id);
}