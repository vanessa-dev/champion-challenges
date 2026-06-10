using Xunit;
using ChampionChallenges.Application.DTOs.User;
using FluentAssertions;

namespace ChampionChallenges.UnitTests.Domain.DTOs.User;

public class UpdatePasswordDtoTests
{
    [Fact]
    public void GivenValidParameters_WhenCreatingUpdatePasswordDto_ThenPropertiesShouldBeSet()
    {
        //Arrange
        var currentPassword = "123456";
        var newPassword = "12345678";
        
        //Act
        var dto = new UpdatePasswordDto(currentPassword, newPassword, newPassword);
        
        //Assert
        dto.CurrentPassword.Should().Be(currentPassword);
        dto.NewPassword.Should().Be(newPassword);
        dto.ConfirmPassword.Should().Be(newPassword);
    }
}