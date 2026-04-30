using ChampionChallenges.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChampionChallenges.Api.Controllers;

public class ChallengeController(IChallengeService challengeService) : ControllerBase
{
    
}