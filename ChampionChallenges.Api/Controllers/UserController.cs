using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Mappers;
using ChampionChallenges.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChampionChallenges.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserService userService) : ControllerBase
{
     [HttpGet]
     public async Task<ActionResult<IList<UserResponseDto>>> GetAll()
     {
        var user =  await userService.GetAll();
        return Ok(user);
     }

     [HttpGet("{id}")]
     public async Task<ActionResult<UserResponseDto>> GetById(Guid id)
     {
         var user = await userService.GetById(id);
         if (user == null)
             return  NotFound();
         
         return Ok(user);
     }

     [HttpPost]
     public async Task<ActionResult<UserResponseDto>> Add([FromBody] CreateUserDto createUserDto)
     {
         var user = await userService.Add(createUserDto);
         return CreatedAtAction(nameof(GetById), new {id = user.Id}, createUserDto);
     }


     [HttpDelete]
     public async Task<ActionResult> Delete(Guid id)
     {
         await userService.Remove(id);
         return NoContent();
     }
     
     [HttpPut]
     public async Task<ActionResult<UserResponseDto>> Update([FromBody] UpdateUserDto updateUserDto)
     {
         await userService.Update(updateUserDto);
         return NoContent();
     }
}