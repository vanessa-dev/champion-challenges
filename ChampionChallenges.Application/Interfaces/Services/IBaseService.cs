using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Interfaces.Services;

public interface IBaseService<TEntity, in TCreateDto, TResponseDto> where TEntity : BaseEntity
{
    public Task<TResponseDto> Add(TCreateDto entity);
    public Task<TResponseDto> Update(TCreateDto entity);
    public Task Remove(Guid id);
    
    public Task<List<TResponseDto>> GetAll();
    public Task<TResponseDto?> GetById(Guid id);
}