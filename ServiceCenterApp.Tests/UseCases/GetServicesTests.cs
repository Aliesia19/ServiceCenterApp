using FluentAssertions;
using NSubstitute;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;
using Xunit;

public class GetServicesTests
{
    private readonly IRepository<Service> _repo = Substitute.For<IRepository<Service>>();
    private readonly GetServices _useCase;

    public GetServicesTests()
    {
        _useCase = new GetServices(_repo);
    }

    [Fact]
    public async Task Should_Return_Services_From_Repository()
    {
        // Arrange
        var services = new List<Service>
        {
            new Service { Id = Guid.NewGuid(), Name = "Fix TV", BasePrice = 100 }
        };

        _repo.GetAllAsync().Returns(services);

        // Act
        var result = await _useCase.Execute();

        // Assert
        result.Should().BeEquivalentTo(services);
        await _repo.Received(1).GetAllAsync();
    }
}