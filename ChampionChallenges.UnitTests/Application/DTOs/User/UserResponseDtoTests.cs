using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Application.DTOs.User;
using FluentAssertions;

namespace ChampionChallenges.UnitTests.Domain.DTOs.User;

public class UserResponseDtoTests
{
    [Fact]
    public void GivenValidUserResponseDto_WhenCreatingResponseDto_ThenShouldCreateUserResponseDto()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Jane Smith";
        var email = "jane.smith@gmail.com";
        var rolePermission = UserRolePermission.Viewer;
        var status = UserStatus.Enabled;
        var createdAt = DateTime.UtcNow.AddDays(-5);
        var updatedAt = DateTime.UtcNow;

        // Act
        var userResponseDto = new UserResponseDto(id, name, email, rolePermission, status, createdAt, updatedAt);

        // Assert
        userResponseDto.Id.Should().Be(id);
        userResponseDto.Name.Should().Be(name);
        userResponseDto.Email.Should().Be(email);
        userResponseDto.RolePermission.Should().Be(rolePermission);
        userResponseDto.Status.Should().Be(status);
        userResponseDto.CreatedAt.Should().Be(createdAt);
        userResponseDto.UpdatedAt.Should().Be(updatedAt);
    }
}