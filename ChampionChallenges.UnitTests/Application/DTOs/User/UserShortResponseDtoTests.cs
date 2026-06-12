using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Application.DTOs.User;
using FluentAssertions;

namespace ChampionChallenges.UnitTests.Domain.DTOs.User;

public class UserShortResponseDtoTests
{
    [Fact]
    public void GivenValidUserShortResponseDto_WhenCreatingShortResponseDto_ThenShouldCreateUserShortResponseDto()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "John Smith";
        var email = "john.smith@gmail.com";
        var rolePermission = UserRolePermission.Operator;
        var status = UserStatus.Enabled;

        // Act
        var userShortResponseDto = new UserShortResponseDto(id, name, email, rolePermission, status);

        // Assert
        userShortResponseDto.Id.Should().Be(id);
        userShortResponseDto.Name.Should().Be(name);
        userShortResponseDto.Email.Should().Be(email);
        userShortResponseDto.RolePermission.Should().Be(rolePermission);
        userShortResponseDto.Status.Should().Be(status);
    }
}
