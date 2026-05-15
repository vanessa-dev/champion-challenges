using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ChampionChallenges.Api.Controllers;

[ApiController]
[Route("api/challenge")]
public class ChallengeController(IChallengeService challengeService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ChallengeResponseDto>> GetById(Guid id)
    {
        var challenge = await challengeService.GetById(id);
        if (challenge == null)
            return  NotFound();
         
        return Ok(challenge);
    }
    
    [HttpPost]
    public async Task<ActionResult<ChallengeResponseDto>> Add([FromBody] CreateChallengeDto createChallengeDto)
    {
        var challenge = await challengeService.Add(createChallengeDto);
        return CreatedAtAction(nameof(GetById), new { id = challenge.Id }, challenge);
    }
}