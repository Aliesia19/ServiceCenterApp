using FluentAssertions;
using ServiceCenterApp.Application.Mappers;
using ServiceCenterApp.Domain.Entities;
using Xunit;

public class EquipmentTypeTests
{
    private readonly EquipmentTypeMapper _mapper = new();

    [Fact]
    public void ToDto_Should_Map()
    {
        var domain = new EquipmentType
        {
            Id = Guid.NewGuid(),
            Name = "Laptop"
        };

        var dto = _mapper.ToDto(domain);

        dto.Id.Should().Be(domain.Id);
        dto.Name.Should().Be("Laptop");
    }

    [Fact]
    public void ToDomain_Should_Map()
    {
        var dto = new EquipmentTypeDto
        {
            Id = Guid.NewGuid(),
            Name = "Laptop"
        };

        var domain = _mapper.ToDomain(dto);

        domain.Id.Should().Be(dto.Id);
        domain.Name.Should().Be(dto.Name);
    }
}