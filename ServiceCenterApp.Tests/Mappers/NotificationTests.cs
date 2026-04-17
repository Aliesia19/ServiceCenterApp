using FluentAssertions;
using ServiceCenterApp.Application.Mappers;
using ServiceCenterApp.Domain.Entities;
using Xunit;

public class NotificationTests
{
    private readonly NotificationMapper _mapper = new();

    [Fact]
    public void ToDto_Should_Map()
    {
        var domain = new Notification
        {
            Id = Guid.NewGuid(),
            Message = "Test",
            IsRead = true
        };

        var dto = _mapper.ToDto(domain);

        dto.Id.Should().Be(domain.Id);
        dto.Message.Should().Be("Test");
        dto.IsRead.Should().BeTrue();
    }

    [Fact]
    public void ToDomain_Should_Map()
    {
        var dto = new NotificationDto
        {
            Id = Guid.NewGuid(),
            Message = "Test",
            IsRead = false
        };

        var domain = _mapper.ToDomain(dto);

        domain.Id.Should().Be(dto.Id);
        domain.Message.Should().Be(dto.Message);
        domain.IsRead.Should().Be(dto.IsRead);
    }
}