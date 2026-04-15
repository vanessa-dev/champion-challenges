using ChampionChallenges.Application.DTOs.Invite;
using ChampionChallenges.Application.Interfaces.Services;

namespace ChampionChallenges.Application.Services;

public class InviteService : IInviteService
{
    public Task<InviteResponseDto> Add(SendInviteDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<InviteResponseDto> Update(SendInviteDto entity)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<InviteResponseDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<InviteResponseDto?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}