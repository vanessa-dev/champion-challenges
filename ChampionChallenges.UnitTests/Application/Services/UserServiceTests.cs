using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Services;
using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Domain.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace ChampionChallenges.UnitTests.Application.Services;

public class UserServiceTests
{
    public static readonly Mock<IUserRepository> _userRepositoryMock = new(MockBehavior.Strict);
    public static readonly Mock<IPasswordHasher<User>> _passwordHasherMock = new(MockBehavior.Strict);
    public readonly IUserService service = new UserService(_userRepositoryMock.Object, _passwordHasherMock.Object);
    
    #region Add
    [Fact]
    public async Task GivenValidDto_WhenAddUser_ThenShouldEncryptPassword()
    {
        //Arrange
        var name  = "John Doe";
        var email = "john.doe@gmail.com";
        var password = "123456";
        var role = UserRolePermission.Operator;
        var status = UserStatus.Enabled;
        
        var userdto = new CreateUserDto(name, email, password, role, status);
        User? savedUser = null;

       _userRepositoryMock.Setup(x => x.GetByEmail(userdto.Email)).ReturnsAsync((User?) null).Verifiable();;
       _passwordHasherMock.Setup(x => x.HashPassword(It.IsAny<User>(), It.Is<string>(p => p == userdto.Password))).Returns("hash_password").Verifiable();
       _userRepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Callback<User>(u  => savedUser = u ).ReturnsAsync((User u) => u).Verifiable();
       
       //Act
       var result = await service.Add(userdto);
       

       //Assert
       result.Should().NotBeNull();
       result.Id.Should().NotBeEmpty();
       result.Name.Should().Be(name);
       result.Email.Should().Be(email);
       result.Status.Should().Be(status);
       result.RolePermission.Should().Be(role);
       
       savedUser.Should().NotBeNull();
       savedUser!.Password.Should().Be("hash_password");
       _userRepositoryMock.Verify(x => x.GetByEmail(userdto.Email), Times.Once);
       _passwordHasherMock.Verify(x => x.HashPassword(It.IsAny<User>(), It.Is<string>(p => p == userdto.Password)));
       _userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
    }

    public async Task GivenInvalidDto_WhenAddUser_ThenShouldReturnNull()
    {
        //Arrange
        //Act
        //Assert
        
    }
    
    #endregion
}