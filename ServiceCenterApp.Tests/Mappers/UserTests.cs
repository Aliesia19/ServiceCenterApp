using FluentAssertions;
using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Mappers;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using Xunit;

public class UserTests
{
    private readonly UserMapper _mapper = new();

    [Fact]
    public void ToDto_Should_Map()
    {
        var domain = new User
        {
            Id = Guid.NewGuid(),
            FullName = "John",
            Email = "test@mail.com",
            Phone = "123",
            Role = UserRole.Client
        };

        var dto = _mapper.ToDto(domain);

        dto.FullName.Should().Be("John");
        dto.Role.Should().Be("Client");
    }

    [Fact]
    public void ToDomain_Should_Map()
    {
        var dto = new UserDto
        {
            Id = Guid.NewGuid(),
            FullName = "John",
            Email = "test@mail.com",
            Phone = "123",
            Role = "Client"
        };

        var domain = _mapper.ToDomain(dto);

        domain.Role.Should().Be(UserRole.Client);
    }
}