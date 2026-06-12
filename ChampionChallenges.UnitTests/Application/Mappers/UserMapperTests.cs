using ChampionChallenges.Application.DTOs.User;
using ChampionChallenges.Application.Mappers;
using ChampionChallenges.Domain.Entities;
using ChampionChallenges.Domain.Enums;
using FluentAssertions;

namespace ChampionChallenges.UnitTests.Application.Mappers;

public class UserMapperTests
{
	[Fact]
	public void GivenCreateUserDto_WhenToEntity_ThenShouldMapAllProperties()
	{
		// Arrange
		var name = "John Doe";
		var email = "john.doe@example.com";
		var password = "hashed_password";
		var role = UserRolePermission.Admin;
		var status = UserStatus.Enabled;

		var dto = new CreateUserDto(name, email, password, role, status);

		// Act
		var entity = dto.ToEntity();

		// Assert
		entity.Name.Should().Be(name);
		entity.Email.Should().Be(email);
		entity.Password.Should().Be(password);
		entity.RolePermission.Should().Be(role);
		entity.UserStatus.Should().Be(status);
	}

	[Fact]
	public void GivenUser_WhenToResponse_ThenShouldMapAllProperties()
	{
		// Arrange
		var name = "Jane Doe";
		var email = "jane.doe@example.com";
		var password = "pwd";
		var role = UserRolePermission.Operator;
		var status = UserStatus.Enabled;

		var user = new User(name, email, password, role, status);

		// Act
		var response = user.ToResponse();

		// Assert
		response.Id.Should().Be(user.Id);
		response.Name.Should().Be(user.Name);
		response.Email.Should().Be(user.Email);
		response.RolePermission.Should().Be(user.RolePermission);
		response.Status.Should().Be(user.UserStatus);
		response.CreatedAt.Should().Be(user.CreatedAt);
		response.UpdatedAt.Should().Be(user.UpdatedAt);
	}

	[Fact]
	public void GivenUser_WhenToShortResponse_ThenShouldMapShortProperties()
	{
		// Arrange
		var user = new User("A", "a@a.com", "p", UserRolePermission.Viewer, UserStatus.Disabled);

		// Act
		var shortResponse = user.ToShortResponse();

		// Assert
		shortResponse.Id.Should().Be(user.Id);
		shortResponse.Name.Should().Be(user.Name);
		shortResponse.Email.Should().Be(user.Email);
		shortResponse.RolePermission.Should().Be(user.RolePermission);
		shortResponse.Status.Should().Be(user.UserStatus);
	}

	[Fact]
	public void GivenUsers_WhenToResponseEnumerable_ThenShouldMapAllItems()
	{
		// Arrange
		var user1 = new User("U1", "u1@a.com", "p1", UserRolePermission.Admin, UserStatus.Enabled);
		var user2 = new User("U2", "u2@a.com", "p2", UserRolePermission.Operator, UserStatus.Disabled);
		var users = new List<User> { user1, user2 };

		// Act
		var responses = users.ToResponse();

		// Assert
		responses.Should().HaveCount(2);
		responses[0].Id.Should().Be(user1.Id);
		responses[1].Id.Should().Be(user2.Id);
	}

	[Fact]
	public void GivenUser_WhenToRequest_ThenShouldCreateCreateUserDto()
	{
		// Arrange
		var user = new User("Req", "req@a.com", "pwd", UserRolePermission.Viewer, UserStatus.Enabled);

		// Act
		var request = user.ToRequest();

		// Assert
		request.Name.Should().Be(user.Name);
		request.Email.Should().Be(user.Email);
		request.Password.Should().Be(user.Password);
		request.RolePermission.Should().Be(user.RolePermission);
		request.Status.Should().Be(user.UserStatus);
	}
}