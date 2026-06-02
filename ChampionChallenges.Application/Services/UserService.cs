using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Mappers;
using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ChampionChallenges.Application.Services;

public class UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher) : IUserService
{
    
    public async Task<UserResponseDto> Add(CreateUserDto requestDto)
    {
       var userExists = await userRepository.GetByEmail(requestDto.Email);
       if (userExists != null)
           throw new Exception("Unable to create user.");
       
       var entity = requestDto.ToEntity();
       entity.Validate();
       entity.ChangePassword(passwordHasher.HashPassword(entity, requestDto.Password));
       
       await userRepository.Create(entity);
       return entity.ToResponse();
    }

    public async Task<UserResponseDto> Update(UpdateUserDto requestDto)
    {
        var user = await userRepository.GetById(requestDto.Id);
        if (user == null)
            throw new Exception("Unable to update the user.");
        
        var userEmailExists = await userRepository.GetByEmail(requestDto.Email);
        if (userEmailExists != null)
            throw new Exception("Unable to update the user.");
        
        user.UpdateData(requestDto.Name, requestDto.Email, requestDto.Permission);
     
        await userRepository.Update(user);
        return user.ToResponse();
    }
    
    public async Task<UserResponseDto> UpdatePassword(Guid userId, UpdatePasswordDto requestDto)
    {
        var user = await userRepository.GetById(userId);
        if (user == null)
            throw new Exception("Unable to update the user.");
        
        var passwordCheck = passwordHasher.VerifyHashedPassword(
            user, 
            user.Password,
            requestDto.CurrentPassword
        );
        
        if(passwordCheck == PasswordVerificationResult.Failed)
            throw new Exception("Current password is invalid.");
        
        user.ChangePassword(passwordHasher.HashPassword(user, requestDto.NewPassword));
        await userRepository.Update(user);
        return user.ToResponse();
    }

    public async  Task Remove(Guid id)
    {
       await userRepository.Remove(id);
    }

    public async Task<IList<UserResponseDto>> GetAll()
    {
       var users = await userRepository.GetAll();
       return users.ToResponse();
    }

    public async Task<PagedResult<UserShortResponseDto>> GetAllPaged(UserFilterRequestDto search)
    {
        var page = search.Page < 1 ? 1 : search.Page;
        var pageSize = search.PageSize < 1 ? 20 : search.PageSize;

        var pagedUsers = await userRepository.GetPaged(pageSize, page, search.Name, search.Email,
            search.RolePermission, search.Status
        );
        
        var items = pagedUsers.Items.ToShortResponse();

        return new PagedResult<UserShortResponseDto>
        {
            Items = items,
            TotalItems = pagedUsers.TotalItems,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<UserResponseDto?> GetById(Guid id)
    {
        var user = await userRepository.GetById(id);
        return user?.ToResponse();
    }

    public async Task<UserResponseDto?> GetByEmail(string email)
    {
        var user = await userRepository.GetByEmail(email);
        return user?.ToResponse();
    }
}