using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Enums;
using ChampionChallenges.Domain.Exceptions;
using FluentAssertions;

namespace ChampionChallenges.UnitTests.Domain.Entities;

public class UserTests
{
    [Fact]
    public void GivenValidParameters_WhenCreateUser_ThenShouldCreateSuccessfully()
    {
        //Arrange
        var name = "John Doe";
        var email = "john.doe@gmail.com";
        var password = "123456";
        var rolePermission = UserRolePermission.Operator;
        var status = UserStatus.Enabled;
        //Act
        var user = new User(name, email, password, rolePermission, status);
        //Assert
        user.Name.Should().Be(name);
        user.Email.Should().Be(email);
        user.Name.Should().NotBeNullOrWhiteSpace();
        user.Email.Should().NotBeNullOrWhiteSpace();
        user.Password.Should().Be(password);
        user.RolePermission.Should().Be(rolePermission);
        user.UserStatus.Should().Be(status);
    }
    
    [Fact]
    public void GivenUserWithDisabledStatus_WhenUpdateStatusToEnabled_ThenStatusShouldBeEnabled()
    {
        //Arrange
        var name = "John Doe";
        var email = "john.doe@gmail.com";
        var password = "123456";
        var rolePermission = UserRolePermission.Operator;
        var status = UserStatus.Disabled;
        var user = new User(name, email, password, rolePermission, status);
        
        //Act
        user.Enable();
        //Assert
        user.UserStatus.Should().Be(UserStatus.Enabled);
    }
    
    [Fact]
    public void GivenUserWithEnabledStatus_WhenUpdateStatusToEnabled_ThenShouldKeepStatusAsEnabled()
    {
        //Arrange
        var name = "John Doe";
        var email = "john.doe@gmail.com";
        var password = "123456";
        var rolePermission = UserRolePermission.Operator;
        var status = UserStatus.Enabled;
        var user = new User(name, email, password, rolePermission, status);
        
        //Act
        user.Enable();
        //Assert
        user.UserStatus.Should().Be(UserStatus.Enabled);
       
    }
    
    [Fact]
    public void GivenUserWithEnabledStatus_WhenUpdateStatusToDisabled_ThenStatusShouldBeDisabled()
    {
        //Arrange
        var name = "John Doe";
        var email = "john.doe@gmail.com";
        var password = "123456";
        var rolePermission = UserRolePermission.Operator;
        var status = UserStatus.Enabled;
        var user = new User(name, email, password, rolePermission, status);
        
        //Act
        user.Disable();
        //Assert
        user.UserStatus.Should().Be(UserStatus.Disabled);
    }
    
    
    [Fact]
    public void GivenUserWithDisabledStatus_WhenTryToUpdatedStatusToDisabled_ThenStatusShouldBeDisabled()
    {
        //Arrange
        var name = "John Doe";
        var email = "john.doe@gmail.com";
        var password = "123456";
        var rolePermission = UserRolePermission.Operator;
        var status = UserStatus.Disabled;
        var user = new User(name, email, password, rolePermission, status);
        
        //Act 
       user.Disable();
        
        //Assert
        user.UserStatus.Should().Be(UserStatus.Disabled);
    }
    
    [Fact]
    public void GivenValidParameters_WhenUpdateUser_ThenShouldUpdateSuccessfully()
    {
        //Arrange
        var name = "John Doe";
        var email = "john.doe@gmail.com";
        var password = "123456";
        var rolePermission = UserRolePermission.Operator;
        var status = UserStatus.Disabled;
        var user = new User(name, email, password, rolePermission, status);
        var newName = "John Doe new";
        var newEmail = "John.doe.new@gmail.com";
        var newRole = UserRolePermission.Viewer;
        
        //Act 
       user.UpdateData(newName, newEmail, newRole);
        
        //Assert
        user.Name.Should().Be(newName);
        user.Email.Should().Be(newEmail);
        user.RolePermission.Should().Be(newRole);
    }
    
    [Fact]
    public void GivenInvalidParameters_WhenCreatingUser_ThenShouldThrownAnException()
    {
        //Arrange
        var name = "John Doe";
        var email = "john.doe.teste";
        var password = "123456";
        var rolePermission = UserRolePermission.Operator;
        var status = UserStatus.Disabled;
        var user = new User(name, email, password, rolePermission, status);
        
        //Act 
        var act = () => user.Validate();
        
        //Assert
        act.Should().Throw<DomainException>().WithMessage("Invalid Fields");
    }
}