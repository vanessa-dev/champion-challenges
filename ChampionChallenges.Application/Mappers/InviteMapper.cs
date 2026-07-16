using ChampionChallenges.Application.DTOs.Invite;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Mappers;

public static class InviteMapper
{
    // TODO: Update this mapper when implementing Invite endpoints
    // The Invite entity now requires ChallengeId in the constructor
    //Converter para entidade
    public static Invite ToEntity(this SendInviteDto dto, Guid challengeId)
    {
        return new Invite(dto.ChallengerId, dto.ChallengedId, challengeId);
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