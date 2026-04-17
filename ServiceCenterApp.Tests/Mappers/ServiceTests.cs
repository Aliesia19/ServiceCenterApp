using FluentAssertions;
using ServiceCenterApp.Application.Mappers;
using ServiceCenterApp.Domain.Entities;
using Xunit;

public class ServiceTests
{
    private readonly ServiceMapper _mapper = new();

    [Fact]
    public void ToDto_Should_Map()
    {
        var domain = new Service
        {
            Id = Guid.NewGuid(),
            Name = "Repair",
            BasePrice = 200
        };

        var dto = _mapper.ToDto(domain);

        dto.Id.Should().Be(domain.Id);
        dto.Name.Should().Be("Repair");
        dto.BasePrice.Should().Be(200);
    }
}