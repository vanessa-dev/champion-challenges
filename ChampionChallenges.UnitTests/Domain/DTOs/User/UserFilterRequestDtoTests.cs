using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Application.DTOs.User;
using FluentAssertions;

namespace ChampionChallenges.UnitTests.Domain.DTOs.User;

public class UserFilterRequestDtoTests
{
    
    [Fact]
    public void GivenCustomUserFilterRequestDto_WhenCreated_ThenShouldRespectProvidedValues()
    {
        // Arrange
        var name = "Alice";
        var email = "alice@example.com";
        var role = UserRolePermission.Admin;
        var status = UserStatus.Enabled;
        var page = 3;
        var pageSize = 50;

        // Act
        var filter = new UserFilterRequestDto
        {
            Name = name,
            Email = email,
            RolePermission = role,
            Status = status,
            Page = page,
            PageSize = pageSize
        };

        // Assert
        filter.Name.Should().Be(name);
        filter.Email.Should().Be(email);
        filter.RolePermission.Should().Be(role);
        filter.Status.Should().Be(status);
        filter.Page.Should().Be(page);
        filter.PageSize.Should().Be(pageSize);
    }
}