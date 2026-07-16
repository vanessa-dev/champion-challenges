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
        return new ChallengeResponseDto(
            challenge.Id, 
            challenge.Name, 
            challenge.Details, 
            challenge.Link, 
            challenge.UserId,
            challenge.StartDate,
            challenge.EndDate,
            challenge.Status
        );
    }

    // Convert Entity to Response with Owner info
    public static ChallengeResponseDto ToResponseWithOwner(this Challenge challenge)
    {
        return new ChallengeResponseDto(
            challenge.Id, 
            challenge.Name, 
            challenge.Details, 
            challenge.Link, 
            challenge.UserId,
            challenge.StartDate,
            challenge.EndDate,
            challenge.Status,
            challenge.Challenger?.Name
        );
    }

    // Convert Entity to Response with full details (owner + invites)
    public static ChallengeResponseDto ToResponseWithDetails(this Challenge challenge)
    {
        var invites = challenge.Invites?
            .Select(i => new InviteSummaryDto(
                i.Id,
                i.ChallengedId,
                i.Challenged?.Name ?? string.Empty,
                i.Status,
                i.InvitedAt,
                i.RespondedAt
            ))
            .ToList();

        return new ChallengeResponseDto(
            challenge.Id, 
            challenge.Name, 
            challenge.Details, 
            challenge.Link, 
            challenge.UserId,
            challenge.StartDate,
            challenge.EndDate,
            challenge.Status,
            challenge.Challenger?.Name,
            invites
        );
    }

    // Convert UpdateDto to apply to existing Entity
    public static void ApplyUpdate(this Challenge challenge, UpdateChallengeDto dto)
    {
        challenge.UpdateData(dto.Name, dto.Details, dto.Link, dto.EndDate, dto.Status);
    }

    public static CreateChallengeDto ToRequest(this Challenge dto)
    {
        return new CreateChallengeDto(dto.Name, dto.Details, dto.Link, dto.UserId);
    }
}