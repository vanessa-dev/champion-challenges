using ChampionChallenges.Application.DTOs.Invite;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Mappers;

public static class InviteMapper
{
    //Converter para entidade
    public static Invite ToEntity(this SendInviteDto dto)
    {
        return new Invite(dto.SenderId, dto.ChallengeId, dto.RecipientId);
    }
    
    //Converter para DTO
    public static InviteResponseDto ToResponse(this Invite invite)
    {
        return new InviteResponseDto(invite.Id, invite.SenderId, invite.ChallengeId,  invite.RecipientId);
    }

    public static SendInviteDto ToRequest(this Invite dto)
    {
        return new SendInviteDto(dto.SenderId, dto.ChallengeId, dto.RecipientId);
    }
}