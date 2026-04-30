using ChampionChallenges.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChampionChallenges.Api.Controllers;

public class AuthController(IUserService userService) : ControllerBase
{
    
}