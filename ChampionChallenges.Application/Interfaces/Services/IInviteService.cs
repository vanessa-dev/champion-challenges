
using ChampionChallenges.Application.DTOs.Invite;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Interfaces.Services;

public interface IInviteService : IBaseService<Invite, SendInviteDto, InviteResponseDto>
{
    
}