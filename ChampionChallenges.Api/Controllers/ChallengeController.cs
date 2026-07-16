using ChampionChallenges.Application.DTOs.Challenge;
using ChampionChallenges.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChampionChallenges.Api.Controllers;

[ApiController]
[Route("api/challenge")]
public class ChallengeController(IChallengeService challengeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IList<ChallengeResponseDto>>> GetAll(
        [FromQuery] Guid? ownerId,
        [FromQuery] Guid? invitedUserId)
    {
        var challenges = await challengeService.GetAll(ownerId, invitedUserId);
        return Ok(challenges);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ChallengeResponseDto>> GetById(Guid id)
    {
        var challenge = await challengeService.GetById(id);
        if (challenge == null)
            return NotFound();
         
        return Ok(challenge);
    }
    
    [HttpPost]
    public async Task<ActionResult<ChallengeResponseDto>> Add([FromBody] CreateChallengeDto createChallengeDto)
    {
        var challenge = await challengeService.Add(createChallengeDto);
        return CreatedAtAction(nameof(GetById), new { id = challenge.Id }, challenge);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateChallengeDto updateChallengeDto)
    {
        await challengeService.Update(updateChallengeDto);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] Guid id)
    {
        await challengeService.Remove(id);
        return NoContent();
    }
}
