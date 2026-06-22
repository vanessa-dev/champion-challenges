using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Application.Interfaces.Services;
using ChampionChallenges.Application.Services;
using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Domain.Exceptions;
using ChampionChallenges.Domain.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace ChampionChallenges.UnitTests.Application.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IPasswordHasher<User>> _passwordHasherMock;
    private readonly IUserService _service;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
        _passwordHasherMock = new Mock<IPasswordHasher<User>>(MockBehavior.Strict);
        _service = new UserService(_userRepositoryMock.Object, _passwordHasherMock.Object);
    }
    
    #region Add
    [Fact]
    public async Task GivenValidDto_WhenAddUser_ThenShouldEncryptPassword()
    {
        //Arrange
        var name  = "John Doe";
        var email = "john.doe@newmail.com";
        var password = "123456";
        var role = UserRolePermission.Operator;
        var status = UserStatus.Enabled;
        
        var userdto = new CreateUserDto(name, email, password, role, status);
        User? savedUser = null;

       _userRepositoryMock.Setup(x => x.GetByEmail(userdto.Email)).ReturnsAsync((User?) null).Verifiable();
       _passwordHasherMock.Setup(x => x.HashPassword(It.IsAny<User>(), It.Is<string>(p => p == userdto.Password))).Returns("hash_password").Verifiable();
       _userRepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Callback<User>(u  => savedUser = u ).ReturnsAsync((User u) => u).Verifiable();
       
       //Act
       var result = await _service.Add(userdto);
       

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

    [Fact]
    public async Task GivenInvalidDto_WhenAddUser_ThenShouldThrowDomainException()
    {
        //Arrange
        var name  = "John Doe";
        var email = "john.doe";
        var password = "123456";
        var role = UserRolePermission.Operator;
        var status = UserStatus.Enabled;
        
        var userdto = new CreateUserDto(name, email, password, role, status);

        _userRepositoryMock.Setup(x => x.GetByEmail(userdto.Email)).ReturnsAsync((User?) null).Verifiable();
        _passwordHasherMock.Setup(x => x.HashPassword(It.IsAny<User>(), It.Is<string>(p => p == userdto.Password))).Returns("hash_password").Verifiable();
        _userRepositoryMock.Setup(x => x.Create(It.IsAny<User>())).ReturnsAsync((User u) => u).Verifiable();
       

        // Act
        var act = () => _service.Add(userdto);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("Invalid Fields");
        _passwordHasherMock.Verify(x => x.HashPassword(It.IsAny<User>(), It.IsAny<string>()), Times.Never);
        _userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
    }
    
    #endregion
    
    #region Update  
    [Fact]
    public async Task GivenValidDto_WhenUpdateUser_ThenShouldUpdateSuccessfully()
    {
        //Arrange
        var user = new User("John", "john@old.com", "hash", UserRolePermission.Operator, UserStatus.Enabled);
        var name  = "John Doe";
        var email = "john.doe@gmail.com";
        var role = UserRolePermission.Operator;
        
        var updateUserDto = new UpdateUserDto(user.Id, name, email, role);

        _userRepositoryMock.Setup(x => x.GetById(user.Id)).ReturnsAsync(user).Verifiable();
        _userRepositoryMock.Setup(x => x.GetByEmail(updateUserDto.Email)).ReturnsAsync((User?)null).Verifiable();
        _userRepositoryMock.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync((User u) => u).Verifiable();
        
        //Act
        var result = await _service.Update(updateUserDto);
        
        //Assert
        result.Should().NotBeNull();
        result.Id.Should().NotBeEmpty();
        result.Name.Should().Be(name);
        result.Email.Should().Be(email);
        result.RolePermission.Should().Be(role);
        _userRepositoryMock.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        _userRepositoryMock.Verify(x => x.GetById(user.Id), Times.Once);
        _userRepositoryMock.Verify(x => x.GetByEmail(updateUserDto.Email), Times.Once);
    }

    [Fact]
    public async Task GivenInvalidDto_WhenUpdateUser_ThenShouldThrowDomainException()
    {
        //Arrange
        var name  = "John Doe";
        var email = "john.doe@gmail.com";
        var role = UserRolePermission.Operator;
        var id   = new Guid("00000000-0000-0000-0000-000000000000");
        
        var updateUserDto = new UpdateUserDto(id, name, email, role);
        
        _userRepositoryMock.Setup(x => x.GetById(id)).ReturnsAsync(It.IsAny<User>()).Verifiable();
        _userRepositoryMock.Setup(x => x.GetByEmail(updateUserDto.Email)).ReturnsAsync((User?) null).Verifiable();
        _userRepositoryMock.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync((User u) => u).Verifiable();

        //Act
        var act = () => _service.Update(updateUserDto);
        await act.Should().ThrowAsync<Exception>().WithMessage("Unable to update the user.");
        _userRepositoryMock.Verify(x => x.GetByEmail(updateUserDto.Email), Times.Never);
        _userRepositoryMock.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
    }
    #endregion
}