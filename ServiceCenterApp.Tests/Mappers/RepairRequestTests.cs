using FluentAssertions;
using ServiceCenterApp.Application.Mappers;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using Xunit;

public class RepairRequestTests
{
    private readonly RepairRequestMapper _mapper = new();

    [Fact]
    public void ToDto_Should_Map()
    {
        var domain = new RepairRequest
        {
            Id = Guid.NewGuid(),
            Client = new User { FullName = "Client A" },
            EquipmentType = new EquipmentType { Name = "Laptop" },
            Status = RequestStatus.New,
            TotalPrice = 500,
            CreatedAt = DateTime.UtcNow
        };

        var dto = _mapper.ToDto(domain);

        dto.Id.Should().Be(domain.Id);
        dto.ClientName.Should().Be("Client A");
        dto.EquipmentType.Should().Be("Laptop");
        dto.Status.Should().Be("New");
        dto.TotalPrice.Should().Be(500);
    }

    [Fact]
    public void ToDomain_Should_Map_Basic()
    {
        var dto = new RepairRequestDto
        {
            Id = Guid.NewGuid(),
            TotalPrice = 500,
            Status = "New",
            CreatedAt = DateTime.UtcNow
        };

        var domain = _mapper.ToDomain(dto);

        domain.Id.Should().Be(dto.Id);
        domain.TotalPrice.Should().Be(500);
        domain.Status.Should().Be(RequestStatus.New);
    }
}