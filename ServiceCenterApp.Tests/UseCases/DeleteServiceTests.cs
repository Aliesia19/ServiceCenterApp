using NSubstitute;
using Xunit;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

namespace ServiceCenterApp.Tests.UseCases;

public class DeleteServiceTests
{
    private readonly IRepository<Service> _repo =
        Substitute.For<IRepository<Service>>();

    private readonly DeleteService _useCase;

    public DeleteServiceTests()
    {
        _useCase = new DeleteService(_repo);
    }

    [Fact]
    public async Task Should_Delete_Service_When_Exists()
    {
        var service = new Service
        {
            Id = Guid.NewGuid(),
            Name = "Test"
        };

        _repo.GetByIdAsync(service.Id).Returns(service);

        await _useCase.Execute(service.Id);

        await _repo.Received(1).DeleteAsync(service);
    }

    [Fact]
    public async Task Should_Do_Nothing_When_Service_Not_Found()
    {
        _repo.GetByIdAsync(Arg.Any<Guid>())
              .Returns((Service?)null);

        await _useCase.Execute(Guid.NewGuid());

        await _repo.DidNotReceive().DeleteAsync(Arg.Any<Service>());
    }
}