using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Application.DTOs.User;
using FluentAssertions;

namespace ChampionChallenges.UnitTests.Domain.DTOs.User;

public class CreateUserDtoTests
{
    [Fact]
    public void GivenValidUserDto_WhenCreatingUser_ThenShouldCreateUser()
    {
        //Arrange
        var name  = "John Doe";
        var email = "john.doe@gmail.com";
        var password = "123456";
        var role = UserRolePermission.Admin;
        var status = UserStatus.Enabled;
        
        //Act
        var userCreateDto = new CreateUserDto(name, email, password, role, status);
        
        //Assert
        userCreateDto.Name.Should().Be(name);
        userCreateDto.Email.Should().Be(email);
        userCreateDto.Password.Should().Be(password);
        userCreateDto.RolePermission.Should().Be(role);
        userCreateDto.Status.Should().Be(status);
    }
}