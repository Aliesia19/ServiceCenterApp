using FluentAssertions;
using ServiceCenterApp.Application.Mappers;
using ServiceCenterApp.Domain.Entities;
using Xunit;

public class ChecklistItemTests
{
    private readonly ChecklistItemMapper _mapper = new();

    [Fact]
    public void ToDto_Should_Map()
    {
        var domain = new ChecklistItem
        {
            Quantity = 2,
            Price = 100,
            Service = new Service { Name = "Repair" }
        };

        var dto = _mapper.ToDto(domain);

        dto.ServiceName.Should().Be("Repair");
        dto.Quantity.Should().Be(2);
        dto.Price.Should().Be(100);
    }

    [Fact]
    public void ToDomain_Should_Map()
    {
        var dto = new ChecklistItemDto
        {
            ServiceName = "Repair",
            Quantity = 2,
            Price = 100
        };

        var domain = _mapper.ToDomain(dto);

        domain.Quantity.Should().Be(2);
        domain.Price.Should().Be(100);
        domain.Service.Name.Should().Be("Repair");
    }
}