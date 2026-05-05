using ChampionChallenges.Application.DTOs.Invite;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Mappers;

public static class InviteMapper
{
    //Converter para entidade
    public static Invite ToEntity(this SendInviteDto dto)
    {
        return new Invite(dto.ChallengedId, dto.ChallengerId);
    }
    
    //Converter para DTO
    public static InviteResponseDto ToResponse(this Invite invite)
    {
        return new InviteResponseDto(invite.Id, invite.ChallengedId, invite.ChallengerId);
    }

    public static SendInviteDto ToRequest(this Invite dto)
    {
        return new SendInviteDto(dto.ChallengedId, dto.ChallengerId);
    }
}