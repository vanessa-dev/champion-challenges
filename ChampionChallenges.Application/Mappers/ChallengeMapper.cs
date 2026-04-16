using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Domain.Entities;

namespace ChampionChallenges.Application.Mappers;

public static class ChallengeMapper
{
    //Converter para entidade
    public static Challenge ToEntity(this CreateChallengeDto dto)
    {
        return new Challenge(dto.Name, dto.Details, dto.Link, dto.UserId);
    }
    
    //Converter para DTO
    public static ChallengeResponseDto ToResponse(this Challenge challenge)
    {
        return new ChallengeResponseDto(challenge.Id, challenge.Name, challenge.Details, challenge.Link, challenge.UserId);
    }

    public static CreateChallengeDto ToRequest(this Challenge dto)
    {
        return new CreateChallengeDto(dto.Name, dto.Details, dto.Link, dto.UserId);
    }
}