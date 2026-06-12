using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Domain.Enums;
using FluentAssertions;

namespace ChampionChallenges.UnitTests.Domain.DTOs.User;

public class UpdateUserDtoTests
{
    [Fact]
    public void GivenValidUserDto_WhenUpdateUserDto_ThenShouldUpdateUserDto()
    {
        //Arrange
        var id = Guid.NewGuid();
        var name  = "John Doe";
        var email = "john.doe@gmail.com";
        var role = UserRolePermission.Viewer;
        
        //Act
        var updateUserDto = new UpdateUserDto(id, name, email, role);
        
        //Assert
        updateUserDto.Id.Should().Be(id);
        updateUserDto.Name.Should().Be(name);
        updateUserDto.Email.Should().Be(email);
        updateUserDto.Permission.Should().Be(role);
    }
}